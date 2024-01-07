//using ProgrammingLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections.Generic; // Make sure to include this for List<>
using System.Diagnostics.Eventing.Reader;
using static System.Windows.Forms.LinkLabel;
using System.Security.Cryptography;
using System.Runtime.CompilerServices;
//using ProgrammingLibrary; // Assuming this is needed for ICommand and related classes

[assembly: System.Runtime.CompilerServices.InternalsVisibleTo("ASE_Programming_LanguageTests1")]
namespace ASE_Programming_Language
{
    public partial class Form1 : Form
    {
        private int number; // Class-level variable
        private int size;   // new variable for size
        private Interpreter interpreter = new Interpreter();
        private List<ICommand> commandsInLoop;
        private object command;
        private readonly IRandomNumberGenerator _randomNumberGenerator;
        public int LastGapMultiplier { get; private set; }
        public double Number { get; internal set; }
        public double SomeConditionFlag { get; internal set; }
        public double String { get; internal set; }

        //private int number;

        public Form1(IRandomNumberGenerator randomNumberGenerator)
        {
            InitializeComponent();
            _randomNumberGenerator = randomNumberGenerator;
            // Create and add the button for drawing shapes
            Button drawButton = new Button
            {
                Text = "R.Shapes",
                Location = new Point(10, 10)
            };
            drawButton.Click += DrawButton_Click;
            Controls.Add(drawButton);

            // Create and add the button for drawing random circles
           // Button btnDrawRandomCircles = new Button
           // {
               // Text = "R.Circles",
               // Location = new Point(200, 290) // Adjust location to avoid overlap
           // };
           // btnDrawRandomCircles.Click += buttonTestLoop_Click;
           // Controls.Add(btnDrawRandomCircles);

        

            // Initialize commandsInLoop
            commandsInLoop = new List<ICommand>();
        }

        private void DrawButton_Click(object sender, EventArgs e)
        {
            DrawCompositeShape();
        }

        private void DrawCompositeShape()
        {
            Random rnd = new Random();

            // Clearing the PictureBox before drawing new shapes
            pictureBox1.Refresh();

            // Getting the Graphics object from the PictureBox
            using (Graphics graphics = pictureBox1.CreateGraphics())
            {
                // Draw a rectangle
                graphics.DrawRectangle(Pens.Black, new Rectangle(rnd.Next(0, 100), rnd.Next(0, 100), rnd.Next(20, 100), rnd.Next(20, 100)));

                // Draw a circle
                int radius = rnd.Next(10, 50);
                graphics.DrawEllipse(Pens.Red, new Rectangle(rnd.Next(0, 100), rnd.Next(0, 100), radius, radius));

                // Draw a line
                graphics.DrawLine(Pens.Blue, new Point(rnd.Next(0, 100), rnd.Next(0, 100)), new Point(rnd.Next(100, 200), rnd.Next(100, 200)));

                // Draw an ellipse
                graphics.DrawEllipse(Pens.Green, new Rectangle(rnd.Next(0, 100), rnd.Next(0, 100), rnd.Next(30, 80), rnd.Next(20, 60)));

                // Draw a polygon (triangle)
                Point[] points = {
            new Point(rnd.Next(0, 200), rnd.Next(0, 200)),
            new Point(rnd.Next(0, 200), rnd.Next(0, 200)),
            new Point(rnd.Next(0, 200), rnd.Next(0, 200))
        };
                graphics.DrawPolygon(Pens.Orange, points);

                // Draw an arc
                graphics.DrawArc(Pens.Purple, new Rectangle(rnd.Next(0, 100), rnd.Next(0, 100), rnd.Next(50, 100), rnd.Next(50, 100)), 0, rnd.Next(180, 360));
            }
        }

        public class ShapeInfo
        {
            public enum ShapeType { Rectangle, Circle, Line, Ellipse, Polygon, Arc }
            public ShapeType Type { get; set; }
            public Rectangle Bounds { get; set; }
            public Point[] Points { get; set; } // For polygons and lines
            public int StartAngle { get; set; } // For arcs
            public int SweepAngle { get; set; } 
        }


        public void DrawShapes(Graphics graphics, List<ShapeInfo> shapes)
        {
            foreach (var shape in shapes)
            {
                switch (shape.Type)
                {
                    case ShapeInfo.ShapeType.Rectangle:
                        graphics.DrawRectangle(Pens.Black, shape.Bounds);
                        break;
                    case ShapeInfo.ShapeType.Circle:
                        graphics.DrawEllipse(Pens.Red, shape.Bounds);
                        break;
                    case ShapeInfo.ShapeType.Line:
                        graphics.DrawLine(Pens.Blue, shape.Points[0], shape.Points[1]);
                        break;
                    case ShapeInfo.ShapeType.Ellipse:
                        graphics.DrawEllipse(Pens.Green, shape.Bounds);
                        break;
                    case ShapeInfo.ShapeType.Polygon:
                        graphics.DrawPolygon(Pens.Orange, shape.Points);
                        break;
                    case ShapeInfo.ShapeType.Arc:
                        graphics.DrawArc(Pens.Purple, shape.Bounds, shape.StartAngle, shape.SweepAngle);
                        break;
                }
            }
        }

       /* private void DrawCompositeShape()
        {
            pictureBox1.Refresh();
            using (Graphics graphics = pictureBox1.CreateGraphics())
            {
                var shapes = GenerateShapes();
                DrawShapes(graphics, shapes);
            }
        }
       */


        private ICommand ParseCommand(string commandText)
        {
            // First, check for multi-line commands
            var lines = commandText.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
            if (lines.Length > 0 && lines[0].Trim().ToLower() == "begin" && lines[lines.Length - 1].Trim().ToLower() == "end")
            {
                List<ICommand> commands = new List<ICommand>();
                for (int i = 1; i < lines.Length - 1; i++)
                {
                    string line = lines[i].Trim().ToLower();
                    string[] commandParts = line.Split(' '); // Renamed to 'commandParts'

                    switch (commandParts[0])
                    {
                        case "draw rectangle":
                            if (commandParts.Length == 5 && int.TryParse(commandParts[1], out int x) && int.TryParse(commandParts[2], out int y) &&
                                int.TryParse(commandParts[3], out int width) && int.TryParse(commandParts[4], out int height))
                            {
                                commands.Add(new CommandDrawRectangle(x, y, width, height));
                            }
                            break;
                        case "draw circle":
                            if (commandParts.Length == 4 && int.TryParse(commandParts[1], out int cx) && int.TryParse(commandParts[2], out int cy) &&
                                int.TryParse(commandParts[3], out int size))
                            {
                                commands.Add(new CommandDrawCircle(size.ToString(), cx, cy)); // Assuming these are the correct parameters
                            }
                            break;
                        case "draw line":
                            if (commandParts.Length == 5 && int.TryParse(commandParts[1], out int sx) && int.TryParse(commandParts[2], out int sy) &&
                                int.TryParse(commandParts[3], out int ex) && int.TryParse(commandParts[4], out int ey))
                            {
                                commands.Add(new CommandDrawLine(new Point(sx, sy), new Point(ex, ey))); // Assuming these are the correct parameters
                            }
                            break;
                            // Add more cases as needed
                    }
                }
                return new CommandMultiLine(commands);
            }









            string[] parts = commandText.Split(' ');

            // Handle variable assignment

            if (parts.Length == 3 && parts[1].Trim() == "=")
            {
                string variableName = parts[0].Trim();
                if (int.TryParse(parts[2].Trim(), out int value))
                {
                    return new CommandVariableAssignment(variableName, value);
                }
            }

            // Handle drawing command
            else if (parts.Length == 2 && parts[0].Trim().ToLower() == "circle")
            {
                // You might want to set default x and y values or allow users to input them
                int defaultX = 0;
                int defaultY = 0;
                return new CommandDrawCircle(parts[1].Trim(), defaultX, defaultY);
            }
            // Handle initialization command
            else if (parts.Length == 4 && parts[0].Trim().ToLower() == "initialize" && parts[2].Trim().ToLower() == "with")
            {
                string variableName = parts[1].Trim();
                if (int.TryParse(parts[3].Trim(), out int value))
                {
                    return new CommandInitialization(variableName, value);
                }
            }
            if (commandText.StartsWith("loop"))
            {
                string[] loopParts = commandText.Substring(4).Trim().Split(' ');
                if (loopParts.Length >= 2 && int.TryParse(loopParts[0], out int loopCount))
                {
                    string[] loopCommands = loopParts[1].Trim(new char[] { '[', ']' }).Split(';');
                    List<ICommand> commands = new List<ICommand>();
                    foreach (string cmd in loopCommands)
                    {
                        ICommand innerCommand = ParseCommand(cmd.Trim());
                        if (innerCommand != null)
                        {
                            commands.Add(innerCommand);
                        }
                    }
                    return new CommandLoop(loopCount, commands);
                }
            }


            // Return null if the input is not recognized
            return null;
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            string commandText = textBox1.Text; // Declare and initialize commandText
            string input = textBox1.Text; // Assuming textBoxCommand is your textbox
            string[] parts = input.Split(' ');
            // Now use commandText in your method calls
            ExecuteMultiLineCommands(commandText);
            string[] lines = commandText.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries); // Split the command text into lines
            List<string> errors = CheckSyntax(lines);

   
           

            ICommand command = ParseCommand(commandText);

            int loopCount = 0; // Declare loopCount here for broader scope
            if (parts.Length >= 2)
            {
                if (parts[0] == "set" && parts[1] == "loop" && int.TryParse(parts[2], out loopCount))
                {
                    // Set loop count variable
                    interpreter.SetVariable("loopCount", loopCount);
                }
                else if (parts[0] == "circle" && parts[1] == "loop")
                {
                    int radius = int.Parse(parts[2]);
                    int xIncrement = int.Parse(parts[3]);
                    int yIncrement = int.Parse(parts[4]);

                    loopCount = interpreter.GetVariableValue("loopCount");
                    int x = 0, y = 0; // Starting position for the first circle

                    for (int i = 0; i < loopCount; i++)
                    {
                        // Add circle command for each iteration
                        using (Graphics graphics = pictureBox1.CreateGraphics())
                        {
                            // Draw the circle at the current position
                            graphics.DrawEllipse(Pens.Black, x, y, radius * 2, radius * 2);

                            // Increment position for the next circle
                            x += xIncrement;
                            y += yIncrement;
                        }
                    }
                }
            }


            // Single-line if statement to check if the commandText is empty
            if (string.IsNullOrWhiteSpace(commandText)) MessageBox.Show("No command entered."); 
             if (command != null)
             {
                 // Check if the command is a graphical command before using graphics
                 if (command is CommandDrawCircle)
                 {
                     // Use the Graphics object of the PictureBox
                     using (Graphics graphics = pictureBox1.CreateGraphics())
                     {
                         command.Execute(interpreter, graphics);
                     }
                 }
                 else
                 {
                     // For non-graphical commands, use the Execute method without Graphics
                    command.Execute(interpreter);

                 }
             }
             else
             {
                 // Handle unrecognized command
             }
            if (errors.Count > 0)
            {
                // Display all errors
                MessageBox.Show("Errors found:\n" + string.Join("\n", errors));
            }
            else
            {
                // Proceed with command execution if no errors
                ExecuteCommands(lines);
            }
        }


        internal void ExecuteMultiLineCommands(string commandText)
        {
            var lines = commandText.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
            using (Graphics graphics = pictureBox1.CreateGraphics());
            bool conditionMet = true;
            bool inIfBlock = true;
            List<string> commandBlock = new List<string>();

            foreach (var line in lines)
            {
                
                        if (line.Trim().ToLower().StartsWith("set number"))
                        {
                            var parts = line.Split(' ');
                            if (parts.Length == 3 && int.TryParse(parts[2], out number))
                            {
                                // Number is successfully set, display the number
                                MessageBox.Show("Number set to: " + number.ToString());
                                continue; // Continue to process other commands
                            }
                            else
                            {
                              //  MessageBox.Show("Invalid number format.");
                                return; // Stop processing further commands
                            }
                        }
                        else
                        {

                            string trimmedLine = line.Trim().ToLower();
                            if (trimmedLine.StartsWith("set number"))
                            {
                                // Existing logic for setting number...
                            }
                            else if (trimmedLine.StartsWith("size = count *"))
                            {
                                string[] parts = trimmedLine.Split('*');
                                if (parts.Length == 2 && int.TryParse(parts[1].Trim(), out int baseSize))
                                {
                                    DrawConcentricCircles(baseSize);
                                }
                                else
                                {
                                    //MessageBox.Show("Invalid format for size command.");
                                }
                            }
                            // ... other command processing logic ...
                        }

                if (conditionMet)
                {
                    string trimmedLine = line.Trim().ToLower();
                    if (trimmedLine.StartsWith("size ="))
                    {
                        string[] parts = trimmedLine.Split('=');
                        if (parts.Length == 2 && int.TryParse(parts[1].Trim(), out int parsedSize))
                        {
                            size = parsedSize; // Set the size variable
                        }
                    }
                    else if (trimmedLine.StartsWith("if size >"))
                    {
                        string[] parts = trimmedLine.Split('>');
                        if (parts.Length == 2 && int.TryParse(parts[1].Trim(), out int comparisonValue))
                        {
                            conditionMet = size > comparisonValue;
                            inIfBlock = true;
                        }
                    }
                    else if (trimmedLine == "endif")
                    {
                        inIfBlock = false;
                        if (conditionMet)
                        {
                            foreach (var cmd in commandBlock)
                            {
                                ProcessCommand(cmd);
                            }
                        }
                        commandBlock.Clear();
                        conditionMet = false;
                    }
                    else if (inIfBlock)
                    {
                        commandBlock.Add(trimmedLine);
                    }
                }
                       // ... (rest of your existing logic for processing if-endif blocks) ...
            }
        }

        private void DrawConcentricCirclesWithGap(int gapMultiplier)
        {
            using (Graphics graphics = pictureBox1.CreateGraphics())
            {
                LastGapMultiplier = gapMultiplier; // Store the value for testing
                pictureBox1.Refresh(); // Clear the PictureBox

                int centerX = pictureBox1.Width / 2;
                int centerY = pictureBox1.Height / 2;

                for (int count = 1; count <= 10; count++)
                {
                    int size = count * gapMultiplier;
                    graphics.DrawEllipse(Pens.Black, centerX - size, centerY - size, size * 2, size * 2);
                }
            }
        }


        public int GetVariableValue(string variableName)
        {
            // Assuming the 'Interpreter' class has a method 'GetVariableValue'
            // that returns the value of a variable given its name.
            return interpreter.GetVariableValue(variableName);
        }



        private void ProcessCommand(string command)
        {
            if (command.StartsWith("print"))
            {
                MessageBox.Show(command.Substring(6));
            }
            // Add more command processing as needed
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void buttonTestLoop_Click(object sender, EventArgs e)
        {
            commandsInLoop.Clear();
            commandsInLoop.AddRange(GenerateRandomCommands(10));

            CommandLoop loopCommand = new CommandLoop(commandsInLoop.Count, commandsInLoop);
            pictureBox1.Refresh();

            using (Graphics graphics = pictureBox1.CreateGraphics())
            {
                foreach (var command in commandsInLoop)
                {
                    if (command is CommandDrawCircle drawCircleCommand)
                    {
                        drawCircleCommand.Execute(interpreter, graphics);
                    }
                }
            }
        }


        public List<ICommand> GenerateRandomCommands(int numberOfCommands)
        {
            List<ICommand> commands = new List<ICommand>();
            for (int i = 0; i < numberOfCommands; i++)
            {
                int x = _randomNumberGenerator.Next(0, pictureBox1.Width);
                int y = _randomNumberGenerator.Next(0, pictureBox1.Height);
                int size = _randomNumberGenerator.Next(10, 100);
                commands.Add(new CommandDrawCircle(size.ToString(), x, y));
            }
            return commands;
        }




        private void button2_Click(object sender, EventArgs e)
        {
            if (int.TryParse(textBox1.Text, out int number) && number > 10)
            {
                MessageBox.Show("The number is greater than 10.");
            }
            else
            {
                MessageBox.Show("Enter a number greater than 10.");
            }
        }





        private bool EvaluateCondition(string conditionLine)
        {
            // Example: "if number > 10"
            var parts = conditionLine.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            if (parts.Length >= 3 && parts[0].ToLower() == "if" && parts[1].ToLower() == "number" && parts[2] == ">" && int.TryParse(parts[3], out int parsedNumber))
            {
                return parsedNumber > 10;
            }
            return false;
        }

        private void DrawConcentricCircles(int baseSize)
        {
            using (Graphics graphics = pictureBox1.CreateGraphics())
            {
                pictureBox1.Refresh(); // Clear the PictureBox

                int centerX = pictureBox1.Width / 2;
                int centerY = pictureBox1.Height / 2;

                for (int count = 1; count <= 10; count++)
                {
                    int size = count * baseSize;
                    graphics.DrawEllipse(Pens.Black, centerX - size, centerY - size, size * 2, size * 2);
                }
            }
        }

        internal List<string> CheckSyntax(string[] lines)
        {
            List<string> errors = new List<string>();
            for (int i = 0; i < lines.Length; i++)
            {
                string line = lines[i].Trim();
                string[] parts = line.Split(' ');


                if (parts.Length == 0 || string.IsNullOrWhiteSpace(parts[0]))
                    continue; // Skip empty lines

                switch (parts[0].ToLower())
                {
                    case "set":
                        if (!(parts.Length == 3 && parts[1] == "loop" && int.TryParse(parts[2], out _)))
                            errors.Add($"Syntax error on line {i + 1}: Invalid 'set loop' command.");
                        break;
                    case "circle":
                        if (parts.Length == 2 && parts[1] == "size")
                        {
                            // 'circle size' command - do nothing as it's valid
                        }
                        else if (!(parts.Length == 5 && parts[1] == "loop" && int.TryParse(parts[2], out _) &&
                            int.TryParse(parts[3], out _) && int.TryParse(parts[4], out _)))
                        {
                            errors.Add($"Syntax error on line {i + 1}: Invalid 'circle' command.");
                        }
                        break;
                    case "size":
                        if (!(parts.Length == 3 && parts[1] == "=" &&
                              (int.TryParse(parts[2], out _) || parts[2].ToLower() == "count * 10")))
                        {
                           // errors.Add($"Syntax error on line {i + 1}: Invalid 'size' assignment.");
                        }
                        break;
                    case "if":
                        if (!(parts.Length >= 4 && parts[1] == "size" && parts[2] == ">" && int.TryParse(parts[3], out _)))
                            errors.Add($"Syntax error on line {i + 1}: Invalid 'if' condition.");
                        break;
                    case "print":
                        if (parts.Length < 2)
                            errors.Add($"Syntax error on line {i + 1}: 'print' command requires additional text.");
                        break;
                    case "endif":
                        if (parts.Length != 1)
                            errors.Add($"Syntax error on line {i + 1}: 'endif' command should not have additional parameters.");
                        break;

                    default:
                        errors.Add($"Syntax error on line {i + 1}: Unknown command '{parts[0]}'.");
                        break;

                }
            }
            return errors;
        }

        private void ExecuteCommands(string[] lines)
        {
            using (Graphics graphics = pictureBox1.CreateGraphics())
            {
                foreach (var line in lines)
                {
                    // Parse the command
                    ICommand command = ParseCommand(line);
                    if (command != null)
                    {
                        if (command is CommandDrawCircle && line == "circle size")
                        {
                            // Execute the CommandDrawCircle with the Graphics object
                            ((CommandDrawCircle)command).Execute(interpreter, graphics);
                        }
                        else
                        {
                            // Execute other commands normally
                            command.Execute(interpreter);
                        }
                    }
                }
            }
        }

        private void ProcessDrawingCommand(string[] parts, Graphics graphics)
        {
            switch (parts[1].ToLower())
            {
                case "rectangle":
                    // Expected format: draw rectangle x y width height
                    if (parts.Length == 6 && int.TryParse(parts[2], out int x) &&
                        int.TryParse(parts[3], out int y) && int.TryParse(parts[4], out int width) &&
                        int.TryParse(parts[5], out int height))
                    {
                        graphics.DrawRectangle(Pens.Black, x, y, width, height);
                    }
                    break;
                case "circle":
                    // Expected format: draw circle x y radius
                    if (parts.Length == 5 && int.TryParse(parts[2], out int cx) &&
                        int.TryParse(parts[3], out int cy) && int.TryParse(parts[4], out int radius))
                    {
                        graphics.DrawEllipse(Pens.Red, cx - radius, cy - radius, radius * 2, radius * 2);
                    }
                    break;
                    // Add cases for other shapes
            }
        }

        internal List<ShapeInfo> GenerateShapes()
        {
            var rnd = new Random();
            var shapes = new List<ShapeInfo>();

            // Add a rectangle
            shapes.Add(new ShapeInfo
            {
                Type = ShapeInfo.ShapeType.Rectangle,
                Bounds = new Rectangle(rnd.Next(0, 100), rnd.Next(0, 100), rnd.Next(20, 100), rnd.Next(20, 100))
            });

            // Add a circle
            int radius = rnd.Next(10, 50);
            shapes.Add(new ShapeInfo
            {
                Type = ShapeInfo.ShapeType.Circle,
                Bounds = new Rectangle(rnd.Next(0, 100), rnd.Next(0, 100), radius * 2, radius * 2)
            });

            // Add a line
            shapes.Add(new ShapeInfo
            {
                Type = ShapeInfo.ShapeType.Line,
                Points = new Point[]
                {
            new Point(rnd.Next(0, 100), rnd.Next(0, 100)),
            new Point(rnd.Next(100, 200), rnd.Next(100, 200))
                }
            });

            // Add an ellipse
            shapes.Add(new ShapeInfo
            {
                Type = ShapeInfo.ShapeType.Ellipse,
                Bounds = new Rectangle(rnd.Next(0, 100), rnd.Next(0, 100), rnd.Next(30, 80), rnd.Next(20, 60))
            });

            // Add a polygon (triangle)
            shapes.Add(new ShapeInfo
            {
                Type = ShapeInfo.ShapeType.Polygon,
                Points = new Point[]
                {
            new Point(rnd.Next(0, 200), rnd.Next(0, 200)),
            new Point(rnd.Next(0, 200), rnd.Next(0, 200)),
            new Point(rnd.Next(0, 200), rnd.Next(0, 200))
                }
            });

            // Add an arc
            shapes.Add(new ShapeInfo
            {
                Type = ShapeInfo.ShapeType.Arc,
                Bounds = new Rectangle(rnd.Next(0, 100), rnd.Next(0, 100), rnd.Next(50, 100), rnd.Next(50, 100)),
                StartAngle = 0,
                SweepAngle = rnd.Next(180, 360)
            });

            return shapes;
        }

    }

}






