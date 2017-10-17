using System;

namespace UltimateOrb.Cil.Verifiable {

    public static partial class SizeOfModule {

        /// <summary>
        ///     <para>
        ///         Returns the result of the CIL <c>sizeof</c> instruction of the specified type.
        ///     </para>
        /// </summary>
        /// <typeparam name="T">
        ///     <para>
        ///         Specifies the type parameter of the instruction.
        ///     </para>
        /// </typeparam>
        /// <returns>
        ///     <para>
        ///         The managed size, in bytes, of a type.
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
        public static uint SizeOf<T>() {
#if FEATURE_USE_STATIC_FIELD
            return SizeOfModule.SizeOf_Typed<T>.Value;
#else
            throw (NotImplementedException)null;
#endif
        }

        /// <summary>
        ///     <para>
        ///         Returns the result of the CIL <c>sizeof</c> instruction of the specified type.
        ///         The result will be converted <c lang="C#">checked</c>-ly to a signed integer before returning it.
        ///     </para>
        /// </summary>
        /// <typeparam name="T">
        ///     <para>
        ///         Specifies the type parameter of the instruction.
        ///     </para>
        /// </typeparam>
        /// <returns>
        ///     <para>
        ///         The managed size, in bytes, of a type.
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
        public static int SizeOfAsSigned<T>() {
            return checked((int)SizeOfModule.SizeOf<T>());
        }

        /// <summary>
        ///     <para>
        ///         Returns the result of the CIL <c>sizeof</c> instruction of the specified type.
        ///         The result will be converted <c lang="C#">unchecked</c>-ly to a signed integer before returning it.
        ///     </para>
        /// </summary>
        /// <typeparam name="T">
        ///     <para>
        ///         Specifies the type parameter of the instruction.
        ///     </para>
        /// </typeparam>
        /// <returns>
        ///     <para>
        ///         The managed size, in bytes, of a type.
        ///     </para>
        /// </returns>
        /// <remarks>
        ///     <para>
        ///         For a reference type, the size returned is the size of a reference value of the corresponding type, not the size of the data stored in objects referred to by a reference value.
        ///     </para>
        /// </remarks>
        [System.CLSCompliantAttribute(true)]
        [System.Runtime.ConstrainedExecution.ReliabilityContractAttribute(System.Runtime.ConstrainedExecution.Consistency.WillNotCorruptState, System.Runtime.ConstrainedExecution.Cer.Success)]
        [System.Runtime.TargetedPatchingOptOutAttribute(null)]
        [System.Runtime.CompilerServices.MethodImplAttribute(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
        // [System.Diagnostics.Contracts.PureAttribute()]
        public static int SizeOfAsSignedUnhecked<T>() {
            return unchecked((int)SizeOfModule.SizeOf<T>());
        }
    }
}

#if FEATURE_USE_STATIC_FIELD
namespace UltimateOrb.Cil.Verifiable {

    public static partial class SizeOfModule {

        /// <devdoc>
        ///     <para>
        ///         This type contains members will be modified by the build tools.
        ///         The build tools use their names to identify the type and those members.
        ///         Whenever you rename this type or such a member, update the build tools accordingly.
        ///     </para>
        /// </devdoc>
        private static partial class SizeOf_Typed<T> {

            public static readonly uint Value = get_Value();

            /// <devdoc>
            ///     <para>
            ///         The method body of this method will be modified by the build tools.
            ///         The build tools use the name to identify the method.
            ///         Whenever you rename this method, update the build tools accordingly.
            ///     </para>
            /// </devdoc>
            [System.Runtime.ConstrainedExecution.ReliabilityContractAttribute(System.Runtime.ConstrainedExecution.Consistency.WillNotCorruptState, System.Runtime.ConstrainedExecution.Cer.Success)]
            [System.Runtime.TargetedPatchingOptOutAttribute(null)]
            [System.Runtime.CompilerServices.MethodImplAttribute(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
            [System.Diagnostics.Contracts.PureAttribute()]
            private static uint get_Value() {
                System.Diagnostics.Contracts.Contract.Ensures(System.Diagnostics.Contracts.Contract.Result<uint>() > 0);
                throw (NotImplementedException)null;
            }
        }
    }
}
#endif
