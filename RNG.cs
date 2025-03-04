using O         = System.Object;
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
using S         = System.String;
using Ex        = System.Exception;
using Math      = System.Math;
using Stopwatch = System.Diagnostics.Stopwatch;

namespace Spelkollektivet {
	public class RNG {
		/* instance variables */

		private S32 iv_seed;

		private System.Random iv_rng;

		private S32 iv_offset = 0;

		/* instance constructors */

		public RNG(S32 pv_seed) {
			iv_seed = pv_seed;

			iv_rng = new(pv_seed);
		}

		public RNG(S32 pv_seed, S32 pv_offset) {
			iv_seed = pv_seed;

			iv_rng = new(pv_seed);

			for(var _i = 0; _i < pv_offset; ++_i) {
				iv_rng.Next();
			}
		}

		/* instance methods */

		private F64 Next() {
			++iv_offset;

			return iv_rng.Next() / (S32.MaxValue - 1.0);
		}

		public S32 Next(S32 pv_min, S32 pv_max) {
			return (S32)System.Math.Round(pv_min + (pv_max - pv_min) * Next());
		}

		public F32 Next(F32 pv_min, F32 pv_max) {
			return (F32)(pv_min + (pv_max - pv_min) * Next());
		}

		public F64 Next(F64 pv_min, F64 pv_max) {
			return (F64)(pv_min + (pv_max - pv_min) * Next());
		}

		public ListItemType Next<ListItemType>(System.Collections.Generic.List<ListItemType> pv_list) {
			return pv_list[Next(0, pv_list.Count - 1)];
		}
	}
}
