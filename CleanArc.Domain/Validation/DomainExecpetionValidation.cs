using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArc.Domain.Validation
{
	public class DomainExecpetionValidation : Exception
	{
		public DomainExecpetionValidation(string error) : base(error) { }

		public static void When(bool hashError, string error)
		{
			if (hashError)
				throw new DomainExecpetionValidation(error);
		}
	}
}
