using System;
using System.Text;

namespace TMStringEditor
{
    class Program
    {
        enum State
        {
            Start,
            Continiue,
            Erase,
            Halt
        }


        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Console.WriteLine("This is TM String Editor");
            Console.Write("Enter a selection of characters : ");
            string input = Console.ReadLine();

            int cell = input.Length - 1;
            StringBuilder tape = new StringBuilder();
            tape.Append(input);
            State state = State.Start;
            char read;
            Console.WriteLine(input + " " + state);

            do
            {
                read = tape[cell];
                if (state == State.Start && read != '$')
                {
                    tape[cell] = read;
                    cell--;
                    state = State.Start;
                    Console.WriteLine(tape + " " + state);
                }
                else if (state == State.Start && read == '*')
                {
                    tape[cell] = '2';
                    cell--;
                    state = State.Start;
                    Console.WriteLine(tape + " " + state);
                }
                else if (state == State.Start && read == '$')
                {
                    tape[cell] = '$';
                    cell--;
                    state = State.Erase;
                    Console.WriteLine(tape + " " + state);
                }
                else if (state == State.Erase && read != '$')
                {
                    tape[cell] = '*';
                    cell--;
                    state = State.Erase;
                    Console.WriteLine(tape + " " + state);
                }
                else if (state == State.Erase && read == '$')
                {
                    tape[cell] = '$';
                    cell--;
                    state = State.Continiue;
                    Console.WriteLine(tape + " " + state);
                }
                else if (state == State.Continiue && read == '*')
                {
                    tape[cell] = '2';
                    cell--;
                    state = State.Continiue;
                    Console.WriteLine(tape + " " + state);
                }
                else if (state == State.Continiue && read != '$')
                {
                    tape[cell] = read;
                    cell--;
                    state = State.Halt;
                    Console.WriteLine(tape + " " + state);
                }
                else if (state == State.Halt)
                {
                    Console.WriteLine(tape + " " + state + "\nTM halted");
                }
            } while (state != State.Halt);
            Console.WriteLine("Simulation results => {0}", tape);
        }
    }
}
