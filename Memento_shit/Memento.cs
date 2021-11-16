using System;
using System.Collections.Generic;
using System.Text;


class Memento : Shape
{
    private readonly Canvas savedCanvasState;

    private Memento(Canvas stateToSave)
    {
        savedCanvasState = stateToSave;
    }

    public class Originator
    {
        private Canvas state;
        public void Set(Canvas state) // Setting the canvas state locally
        {
            this.state = state;
        }

        public Memento SaveToMemento() // Saving canvas to memento 
        {
            return new Memento(state);
        }

        public void RestoreFromMemento(Memento memento) // Restoring version of canvas from memento
        {
            state = memento.savedCanvasState;
        }
    }
}

