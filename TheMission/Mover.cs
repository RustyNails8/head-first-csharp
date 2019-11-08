﻿using System;
using System.Drawing;

namespace TheMission
{
    public abstract class Mover
    {
        private const int MoveInterval = 10;

        protected Point location;
        protected Game game;

        public Point Location => location;

        protected Mover(Game game, Point location)
        {
            // Instâncias de Mover recebem como parâmetro o objeto Game
            // e uma posição atual.

            this.game = game;
            this.location = location;
        }

        public bool Nearby(Point locationToCheck, int distance)
        {
            // Pega um ponto e calcula se ele está a uma certa distância do objeto.
            // Checa a distância de um Point em relação à posição atual do objeto.
            // Se eles estierem a uma distância - definida por distance - de cada um,
            // ele retorna true; senão, retorna false.

            return Math.Abs(location.X - locationToCheck.X) < distance &&
                Math.Abs(location.Y - locationToCheck.Y) < distance;
        }

        public virtual Point Move(Direction direction, Rectangle boundaries)
        {
            // Recebe uma direção, assim como os limites da masmorra, e calcula
            // onde seria o ponto final desse movimento.
            // Tenta move-se um passo em uma direção. Se conseguir, retorna o novo
            // Point. Se chegar em um dos limites, retorna o Point original.

            Point newLocation = location;
            switch (direction)
            {
                case Direction.Up:
                    if (newLocation.Y - MoveInterval >= boundaries.Top)
                    {
                        newLocation.Y -= MoveInterval;
                    }
                    break;

                case Direction.Down:
                    if (newLocation.Y - MoveInterval <= boundaries.Bottom)
                    {
                        newLocation.Y += MoveInterval;
                    }
                    break;

                case Direction.Left:
                    if (newLocation.X - MoveInterval >= boundaries.Left)
                    {
                        newLocation.X -= MoveInterval;
                    }
                    break;

                case Direction.Right:
                    if (newLocation.X + MoveInterval <= boundaries.Right)
                    {
                        newLocation.X += MoveInterval;
                    }
                    break;
            }
            return newLocation;
        }
    }
}