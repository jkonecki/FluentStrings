﻿using System;

namespace dokas.FluentStrings.Actions.Truncate
{
    public class TruncateStringFrom
    {
        private readonly TruncateString _truncateText;
        private readonly The _position;

        internal TruncateStringFrom(TruncateString truncateText, The position)
        {
            _truncateText = truncateText;
            _position = position;
        }

        public static implicit operator string(TruncateStringFrom truncateTextFrom)
        {
            return truncateTextFrom.ToString();
        }

        public override string ToString()
        {
            switch (_position)
            {
                case The.Beginning:
                    return _truncateText;
                case The.End:
                    if (_truncateText.Source != null)
                    {
                        if (_truncateText.Source.Length <= _truncateText.CharsCount)
                            return _truncateText.Source;
                        else
                        {
                            int startingPoint = _truncateText.Source.Length - _truncateText.CharsCount;
                            return _truncateText.Source.Substring(startingPoint);
                        }
                    }
                    return null;
                case The.StartOf:
                case The.EndOf:
                default:
                    throw new ArgumentOutOfRangeException("position", "Only Beginning and End positions are supported by TruncateTo().From() method");
            }
        }
    }
}