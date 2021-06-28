using System;
using System.Drawing;
using System.Windows.Forms;

namespace Kalkulator
{
    public partial class Form1 : Form
    {
        private Calc calc = new Calc(Calculator.Add);
        private double numberA = 0, numberB = 0, result;
        private bool isPrintedResult = false;
        private string operation = "";
        private char character = ' ';

        public Form1()
        {
            InitializeComponent();
        }
        private void Print()
        {
            if (isPrintedResult)
            {
                operation = result.ToString();
            }
            if (character == ' ')
            {
                operation = numberA.ToString();
            }
            else if (character != ' ' && numberB == 0)
            {
                operation = numberA.ToString() + " " + character.ToString();
            }
            else if (character != ' ' && Math.Abs(numberB) > 0)
            {
                operation = numberA.ToString() + " " + character.ToString() + " " + numberB.ToString();
            }
            label1.Text = operation;
        }
        private void LabelClick(object sender, EventArgs e)
        {
            Label lbl = sender as Label;
            if (operation == result.ToString() && isPrintedResult)
            {
                numberA = 0;
                numberB = 0;
                character = ' ';
                AddNumber(int.Parse(lbl.Text));
            }
            else
            {
                AddNumber(int.Parse(lbl.Text));
            }
            Print();
            isPrintedResult = false;
        }
        private void AddNumber(int a)
        {
            if (character == ' ')
            {
                numberA *= 10;
                if (numberA >= 0)
                    numberA += a;
                else
                    numberA -= a;
            }
            else
            {
                numberB *= 10;
                if (numberB >= 0)
                    numberB += a;
                else
                    numberB -= a;
            }
        }
        private void LabelClickPowerOfTwo(object sender, EventArgs e)
        {
            calc = Calculator.PowerOfTwo;
            result = calc(numberA, 0);
            operation = result.ToString();
            label1.Text = operation;
            isPrintedResult = true;
            numberA = result;
            numberB = 0;
        }
        private void LabelClickCharacter(object sender, EventArgs e)
        {
            Label lbl = sender as Label;
            character = char.Parse(lbl.Text);
            numberB = 0;
            Print();
        }
        private void LabelClickSquare(object sender, EventArgs e)
        {
            calc = Calculator.Square;
            if (numberA <= 0)
            {
                numberA = 0;
                operation = numberA.ToString();
                label1.Text = operation;
            }
            else
            {
                result = calc(numberA, 0);
                operation = result.ToString();
                label1.Text = operation;
                isPrintedResult = true;
                numberA = result;
                numberB = 0;
            }
        }
        private void LabelClickNegation(object sender, EventArgs e)
        {
            calc = Calculator.Negation;
            if (isPrintedResult)
            {
                isPrintedResult = false;
                numberA = calc(result, 0);
            }
            else
            {
                if (character == ' ')
                    numberA = calc(numberA, 0);
                else if (character != ' ' && numberB == 0)
                    numberA = calc(numberA, numberB);
                else if (character != ' ' && Math.Abs(numberB) > 0)
                {
                    if (character == '+')
                        character = '-';
                    else if (character == '-')
                        character = '+';
                    else
                    {
                        numberB = calc(numberB, 0);
                    }
                }
            }
            Print();
        }
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue >= 48 && e.KeyValue <= 57)
            {//Funkcja pozwala na wpisywanie liczb do kalkulatora z klawiatury
                switch (e.KeyValue)
                {
                    case 48:
                        AddNumber(0);
                        break;
                    case 49:
                        AddNumber(1);
                        break;
                    case 50:
                        AddNumber(2);
                        break;
                    case 51:
                        AddNumber(3);
                        break;
                    case 52:
                        AddNumber(4);
                        break;
                    case 53:
                        AddNumber(5);
                        break;
                    case 54:
                        AddNumber(6);
                        break;
                    case 55:
                        AddNumber(7);
                        break;
                    case 56:
                        AddNumber(8);
                        break;
                    case 57:
                        AddNumber(9);
                        break;
                }
            }
            Print();
        }
        private void RemoveOne(object sender, EventArgs e)
        {
            if (numberB != 0)
                numberB = ((int)(numberB / 10));
            else if (numberB == 0 && character != ' ')
                character = ' ';
            else if (numberB == 0 && character == ' ' && Math.Abs(numberA) > 0)
                numberA = ((int)(numberA / 10));
            Print();
        }
        private void RemoveAll(object sender, EventArgs e)
        {
            isPrintedResult = false;
            numberA = 0;
            numberB = 0;
            character = ' ';
            Print();
        }
        private void PrintResult(object sender, EventArgs e)
        {
            Label lbl = sender as Label;
            switch (character)
            {
                case '+':
                    calc = Calculator.Add;
                    result = calc(numberA, numberB);
                    break;
                case '-':
                    calc = Calculator.Substract;
                    result = calc(numberA, numberB);
                    break;
                case '*':
                    calc = Calculator.Multiply;
                    result = calc(numberA, numberB);
                    break;
                case '/':
                    calc = Calculator.Divide;
                    result = calc(numberA, numberB);
                    break;
            }
            isPrintedResult = true;
            label1.Text = result.ToString();
            operation = result.ToString();
            numberA = result;
            character = ' ';
        }
        private void labelMouseEnter(object sender, EventArgs e)
        {
            Label label = sender as Label;
            label.BackColor = SystemColors.ButtonFace;
        }
        private void labelMouseExit(object sender, EventArgs e)
        {
            Label label = sender as Label;
            label.BackColor = SystemColors.ButtonHighlight;
        }
    }
}
