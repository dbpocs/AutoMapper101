using System;

namespace AutoMApper101.Application.Commands
{
    public class SampleDTOOut
    {
        public string Name { get; set; }
        public YearOfBirth YearOfBirth { get; set; }
    }

    public class YearOfBirth
    {
        public int Value { get; set; }
    }
}