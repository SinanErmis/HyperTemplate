using UnityEngine;

namespace Rhodos.Toolkit
{
    public class Direction
    {
        private readonly Vector2Int _direction;
        private readonly Types _directionType;

        private Direction(Vector2Int dir, Types directionType)
        {
            _direction = dir;
            _directionType = directionType;
        }

        public static implicit operator Vector2Int(Direction direction) => direction._direction;

        public static implicit operator Vector3Int(Direction direction) =>
            new Vector3Int(((Vector2Int) direction).x, 0, ((Vector2Int) direction).y);

        public static implicit operator Types(Direction direction) => direction._directionType;

        public static readonly Direction Up = new Direction(Vector2Int.up, Types.Up);
        public static readonly Direction Down = new Direction(Vector2Int.down, Types.Down);
        public static readonly Direction Right = new Direction(Vector2Int.right, Types.Right);
        public static readonly Direction Left = new Direction(Vector2Int.left, Types.Left);

        public enum Types
        {
            Up,
            Down,
            Right,
            Left
        }
    }
}