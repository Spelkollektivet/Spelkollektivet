#nullable enable

using B         = System.Boolean;
using S8        = System.SByte;
using S16       = System.Int16;
using S32       = System.Int32;
using S64       = System.Int64;
using U8        = System.Byte;
using U16       = System.UInt16;
using U32       = System.UInt32;
using U64       = System.UInt64;
using F32       = System.Single;
using F64       = System.Double;
using F128      = System.Decimal;
using O         = System.Object;
using T         = System.Type;
using S         = System.String;
using Ex        = System.Exception;
using Math      = System.Math;

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Spelkollektivet {
	public class Stopwatch {
		/* instance variables */

		private System.Diagnostics.Stopwatch iv_stopwatch = new();

		private S iv_name;

		private F64 iv_elapsed_time = 0.0;

		private List<(S name, S? description, F64 elapsed_time)> iv_intervals = new();

		/* instance constructors */

		public Stopwatch(S pv_name) {
			iv_name = pv_name;

			iv_stopwatch.Start();
		}

		/* instance System.Object methods */

		public override S ToString() {
			return $"{iv_name.PadRight(32, '.')}: {iv_elapsed_time:0.000} ms\n{S.Join("\n", iv_intervals.Select(_interval => $"{_interval.name.PadRight(32, '.')}: {_interval.elapsed_time:0.000} ms{(_interval.description is null ? "" : $" ({_interval.description})")}"))}";
		}

		/* instance methods */

		public void Time() {
			var _elapsed_time = iv_stopwatch.Elapsed.TotalMilliseconds;

			iv_elapsed_time += _elapsed_time;

			iv_stopwatch.Restart();
		}

		public void Time(S pv_name, S? pv_description = null) {
			var _elapsed_time = iv_stopwatch.Elapsed.TotalMilliseconds;

			iv_elapsed_time += _elapsed_time;

			iv_intervals.Add((pv_name, pv_description, _elapsed_time));

			iv_stopwatch.Restart();
		}
	}
}
