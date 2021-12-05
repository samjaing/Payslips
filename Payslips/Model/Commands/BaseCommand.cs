using System;
using System.Collections.Generic;
using System.Text;

namespace Payslips.Model.Commands
{
    public abstract class BaseCommand : ICommand
    {
        public string Name { get; set; }
    }
}
