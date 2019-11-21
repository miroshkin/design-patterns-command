using System;

namespace DesignPatterns_Command
{
    //original source https://metanit.com/sharp/patterns/3.3.php

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Design Patterns - Command!");

            RemoteControl remoteControl = new RemoteControl();
            TV tv = new TV();

            remoteControl.SetCommand(new TvTurnOnCommand(tv));
            remoteControl.PressButton();
            remoteControl.PressUndo();
        }
    }

    public interface ICommand
    {
        void Execute();
        void Undo();
    }

    public class RemoteControl
    {
        ICommand _command;

        public RemoteControl(){}

        public void SetCommand (ICommand command)
        {
            _command = command;
        }

        public void PressButton()
        {
            _command?.Execute();
        }

        public void PressUndo()
        {
            _command?.Undo();
        }
    }

    public class TV
    {
        public void On()
        {
            Console.WriteLine("TV is turned ON");
        }

        public void Off()
        {
            Console.WriteLine("TV is turned OFF");
        }
    }

    public class TvTurnOnCommand : ICommand
    {
        private TV _tv;

        public TvTurnOnCommand(TV tv)
        {
            _tv = tv;
        }

        public void Execute()
        {
            _tv.On();
        }

        public void Undo()
        {
            _tv.Off();
        }
    }
}
