using System;

namespace UltimateOrb.Cil.Verifiable {

    public static partial class SizeOfModule {

        /// <summary>
        ///     <para>Represents the number of bits in a byte.</para>
        /// </summary>
        public const int BitsPerByte = 8;

        /// <summary>
        ///     <para>
        ///         Returns the bit size of the specified type.
        ///     </para>
        /// </summary>
        /// <typeparam name="T">
        ///     <para>
        ///         Specifies the type.
        ///     </para>
        /// </typeparam>
        /// <returns>
        ///     <para>
        ///         The managed size, in bits, of a type.
        ///     </para>
        /// </returns>
        /// <remarks>
        ///     <para>
        ///         For a reference type, the size returned is the size of a reference value of the corresponding type, not the size of the data stored in objects referred to by a reference value.
        ///     </para>
        /// </remarks>
        [System.CLSCompliantAttribute(false)]
        [System.Runtime.ConstrainedExecution.ReliabilityContractAttribute(System.Runtime.ConstrainedExecution.Consistency.WillNotCorruptState, System.Runtime.ConstrainedExecution.Cer.Success)]
        [System.Runtime.TargetedPatchingOptOutAttribute(null)]
        [System.Runtime.CompilerServices.MethodImplAttribute(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
        // [System.Diagnostics.Contracts.PureAttribute()]
        public static ulong BitSizeOf<T>() {
#if FEATURE_USE_STATIC_FIELD
            return SizeOfModule.BitSizeOf_Typed<T>.Value;
#else
            return unchecked((ulong)SizeOfModule.BitsPerByte * (ulong)SizeOfModule.SizeOf<T>());
#endif
        }

        /// <summary>
        ///     <para>
        ///         Returns the bit size of the specified type.
        ///         The result will be converted <c lang="C#">checked</c>-ly to an <c lang="C#">int</c> before returning it.
        ///     </para>
        /// </summary>
        /// <typeparam name="T">
        ///     <para>
        ///         Specifies the type.
        ///     </para>
        /// </typeparam>
        /// <returns>
        ///     <para>
        ///         The managed size, in bits, of a type.
        ///     </para>
        /// </returns>
        /// <remarks>
        ///     <para>
        ///         For a reference type, the size returned is the size of a reference value of the corresponding type, not the size of the data stored in objects referred to by a reference value.
        ///     </para>
        /// </remarks>
        [System.Runtime.ConstrainedExecution.ReliabilityContractAttribute(System.Runtime.ConstrainedExecution.Consistency.WillNotCorruptState, System.Runtime.ConstrainedExecution.Cer.MayFail)]
        [System.Runtime.TargetedPatchingOptOutAttribute(null)]
        [System.Runtime.CompilerServices.MethodImplAttribute(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
        // [System.Diagnostics.Contracts.PureAttribute()]
        public static int BitSizeOfAsInt<T>() {
            return checked((int)SizeOfModule.BitSizeOf<T>());
        }

        /// <summary>
        ///     <para>
        ///         Returns the bit size of the specified type.
        ///         The result will be converted <c lang="C#">unchecked</c>-ly to an <c lang="C#">int</c> before returning it.
        ///     </para>
        /// </summary>
        /// <typeparam name="T">
        ///     <para>
        ///         Specifies the type.
        ///     </para>
        /// </typeparam>
        /// <returns>
        ///     <para>
        ///         The managed size, in bits, of a type.
        ///     </para>
        /// </returns>
        /// <remarks>
        ///     <para>
        ///         For a reference type, the size returned is the size of a reference value of the corresponding type, not the size of the data stored in objects referred to by a reference value.
        ///     </para>
        /// </remarks>
        [System.Runtime.ConstrainedExecution.ReliabilityContractAttribute(System.Runtime.ConstrainedExecution.Consistency.WillNotCorruptState, System.Runtime.ConstrainedExecution.Cer.Success)]
        [System.Runtime.TargetedPatchingOptOutAttribute(null)]
        [System.Runtime.CompilerServices.MethodImplAttribute(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
        // [System.Diagnostics.Contracts.PureAttribute()]
        public static int BitSizeOfAsIntUnhecked<T>() {
            return unchecked((int)SizeOfModule.BitSizeOf<T>());
        }
    }
}

#if FEATURE_USE_STATIC_FIELD
namespace UltimateOrb.Cil.Verifiable {

    public static partial class SizeOfModule {

        private static partial class BitSizeOf_Typed<T> {

            public static readonly ulong Value = get_Value();

            [System.Runtime.ConstrainedExecution.ReliabilityContractAttribute(System.Runtime.ConstrainedExecution.Consistency.WillNotCorruptState, System.Runtime.ConstrainedExecution.Cer.Success)]
            [System.Runtime.TargetedPatchingOptOutAttribute(null)]
            [System.Runtime.CompilerServices.MethodImplAttribute(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
            [System.Diagnostics.Contracts.PureAttribute()]
            private static ulong get_Value() {
                return unchecked((ulong)SizeOfModule.BitsPerByte * (ulong)SizeOfModule.SizeOf_Typed<T>.Value);
            }
        }
    }
}
#endif
