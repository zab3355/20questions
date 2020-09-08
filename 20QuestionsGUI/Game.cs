/* GUI - Main game GUI, holds click events, timers and other features.
 * editor: Zach Brown
 * date: 3/30/2018
 * assignment: 20 Questions Game GUI
 * professor: Eric Baker
 * course: IGME 201
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _20QuestionsGUI
{
    public partial class Game : Form
    {
        //Global variables
        private BinTree binTree;
        private Node currentNode;

        //Constuctor
        public Game()
        {
            InitializeComponent();
            binTree = new BinTree();
            binTree.ReadTree();

            currentNode = binTree.Root.Left;
            questionLabel.Text =  "Is this person " + currentNode.Data + "?";


        }

        //Yes button if clicked event
        private void yesBtn_Click(object sender, EventArgs e)
        {
            if (currentNode.Left == null && currentNode.Right == null) 
            {
                questionLabel.Text = "Haha I won!";

                //Timer
                Timer timer = new Timer();
                timer.Interval = 3000;
                timer.Tick += CloseGame;
                timer.Start();

                yesBtn.Visible = false;
                noBtn.Visible = false;
            }
            else
            {
                currentNode = currentNode.Left;
                questionLabel.Text = "Is this person " + currentNode.Data + "?";
            }
        }

        //new method
        private void CloseGame(object sender, EventArgs e)
        {
            this.Close();
        }

        //No button if clicked event
        private void noBtn_Click(object sender, EventArgs e)
        {
            if (currentNode.Left == null && currentNode.Right == null)
            {
                questionLabel.Text = "OK";
                textBox1.Visible = true;
                traitBox.Text = "What is this person that " + currentNode.Data + " isnt?";
                submitBtn.Visible = true;
                traitBox.Visible = true;
                yesBtn.Visible = false;
                noBtn.Visible = false;
            }
            else
            {
                currentNode = currentNode.Right;
                questionLabel.Text = "Is this person " + currentNode.Data + "?";
            }
        }

        //submit button event click
        private void submitBtn_Click(object sender, EventArgs e)
        {
            string person = textBox1.Text;
            string personTrait = traitBox.Text;
            string currentPerson = currentNode.Data;

            currentNode.Data = personTrait;

            //create new yes node and no node for the current person
            Node yesNode = new Node(person);
            currentNode.Left = yesNode;
            Node noNode = new Node(currentPerson);
            currentNode.Right = noNode;
            questionLabel.Text = "I love to learn new things!";

            submitBtn.Visible = false;

            //return statements
            binTree.WriteTree();

            //Timer
            Timer timer = new Timer();
            timer.Interval = 3000;
            timer.Tick += CloseGame;
            timer.Start();
            
        }
    }
}
