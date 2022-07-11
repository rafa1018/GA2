﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace GA2.Application.Main.TU
{
    public class XmlTextEncoder : TextReader
    {
        public static string Encode(string s)
        {
            using (var stream = new StringReader(s))
            using (var encoder = new XmlTextEncoder(stream))
            { return encoder.ReadToEnd(); }
        }
        public XmlTextEncoder(TextReader source, bool filterIllegalChars = true)
        {
            _source = source;
            _filterIllegalChars = filterIllegalChars;
        }
        readonly Queue<char> _buf = new Queue<char>();
        readonly bool _filterIllegalChars;
        readonly TextReader _source;
        public override int Peek()
        {
            PopulateBuffer();
            if (_buf.Count == 0)
                return -1;
            return _buf.Peek();
        }
        public override int Read()
        {
            PopulateBuffer();
            if (_buf.Count == 0)
                return -1;
            return _buf.Dequeue();
        }
        void PopulateBuffer()
        {
            const int endSentinel = -1; while (_buf.Count == 0 && _source.Peek() != endSentinel)
            {
                var c = (char)_source.Read();
                if (Entities.ContainsKey(c))
                {
                    foreach (var i in Entities[c]) _buf.Enqueue(i);
                }
                else if (!(0x0 <= c && c <= 0x8)
                    && !new[] { 0xB, 0xC }.Contains(c)
                    && !(0xE <= c && c <= 0x1F)
                    && !(0x7F <= c && c <= 0x84)
                    && !(0x86 <= c && c <= 0x9F)
                    && !(0xD800 <= c && c <= 0xDFFF)
                    && !new[] { 0xFFFE, 0xFFFF }.Contains(c))
                {
                    _buf.Enqueue(c);
                }
                else if (char.IsHighSurrogate(c)
                    && _source.Peek() != endSentinel
                    && char.IsLowSurrogate((char)_source.Peek()))
                {
                    _buf.Enqueue(c);
                    _buf.Enqueue((char)_source.Read());
                }
                else if (!_filterIllegalChars)
                {
                    throw new ArgumentException(String.Format("Illegal character: '{0:X}'", (int)c));
                }
            }
        }
        static readonly Dictionary<char, string> Entities =
            new Dictionary<char, string> { { '"', "&quot;" }/*, { '&', "&amp;" }*/, { '\'', "&apos;" }, { '<', "&lt;" }, { '>', "&gt;" }, };

    }
}
