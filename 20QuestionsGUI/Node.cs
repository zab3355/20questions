/* Node class - Nodes have a string and 2 child Node pointers.
 * The children are either both null (a leaf node => string is a name)
 * or they're both non-null (an branch node => string is a phrase)
 * BinTree needs access to all the Node attributes, which means that
 * they all have public properties.
 * 
 * 
 * editor: Zach Brown
 * date: 3/18/2018
 * assignment: 20 Questions Game
 * professor: Eric Baker
 * course: IGME 201
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20QuestionsGUI
{
    public class Node
    {
        //attributes
        public string data;
        public string Data
        {
            get
            {
                return data;
            }
            set
            {
                data = value;
            }
        }

        //node left getters and setters
        private Node left;
        public Node Left
        {
            get
            {
                return left;
            }
            set
            {
                left = value;
            }
        }

        //node right getters and setters
        private Node right;
        public Node Right
        {
            get
            {
                return right;
            }
            set
            {
                right = value;
            }
        }

        public Node(string pData)
        {
            data = pData;
        }

        //method to define Display
        public void Display()
        {
            Console.WriteLine(data);
        }
    }
}

