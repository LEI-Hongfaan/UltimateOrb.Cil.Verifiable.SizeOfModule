using Mono.Cecil;
using Mono.Cecil.Cil;
using System;
using System.IO;
using System.Linq;

namespace ThisAssembly {

    public static class Program {

        public static readonly bool UseStaticField = false;

        public enum ExitStatus {
            OK,
            UserCanceled,
            RequestFailed
        }

        public static int Main(string[] args) {
            for (; null != args;) {
                try {
                    var fileName = args?[0];
                    if (null == fileName) {
                        return (int)ExitStatus.UserCanceled;
                    }
                    var dirName = Path.GetDirectoryName(fileName);
                    var fileNameShort = Path.GetFileNameWithoutExtension(fileName);
                    var fileNameExt = Path.GetExtension(fileName);

                    var fileName_Original = Path.Combine(dirName, fileNameShort + fileNameExt);
                    var fileName_Modified = Path.Combine(dirName, fileNameShort + @".tmp");
                    var fileName_Backup = Path.Combine(dirName, fileNameShort + @".bak");
                    var fullpath = Path.GetFullPath(fileName_Original);
                    var rm = new ReaderParameters();
                    rm.InMemory = true;
                    var assembly = AssemblyDefinition.ReadAssembly(fileName_Original, rm);
                    var module = assembly.MainModule;
                    var modified = 0;
                    {
                        var typeref = module.GetType(@"UltimateOrb.Cil.Verifiable.SizeOfModule/SizeOf_Typed`1", false);
                        if (typeref is TypeDefinition type) {
                            var tp = type.GenericParameters?[0];
                            if (null != tp) {
                                var collection = type.Methods;
                                foreach (var method in collection) {
                                    if (@"get_Value" != method.Name) {
                                        continue;
                                    }
                                    if (!method.HasBody) {
                                        continue;
                                    }
                                    {
                                        var bd = method.Body;
                                        var ins = bd.Instructions;
                                        if (2 > ins.Count) {
                                            continue;
                                        }
                                        var ilg = (ILProcessor)null;
                                        var insa = ins.ToArray();
                                        for (var i = 1; insa.Length > i; ++i) {
                                            var in1 = insa[i];
                                            if (OpCodes.Throw != in1.OpCode) {
                                                continue;
                                            }
                                            var in0 = insa[i - 1];
                                            if (OpCodes.Ldnull != in0.OpCode) {
                                                continue;
                                            }
                                            ilg = bd.GetILProcessor();
                                            ilg.Replace(in0, ilg.Create(OpCodes.Sizeof, tp));
                                            ilg.Replace(in1, ilg.Create(OpCodes.Ret));
                                            ++modified;
                                        }
                                        if (null != ilg) {
                                            var ignored = 0;
                                        }
                                    }
                                }
                            }
                        }
                    }
                    if (!UseStaticField) {
                        var typeref = module.GetType(@"UltimateOrb.Cil.Verifiable.SizeOfModule", false);
                        if (typeref is TypeDefinition type) {
                            var collection = type.Methods;
                            foreach (var method in collection) {
                                if (@"SizeOf" != method.Name) {
                                    continue;
                                }
                                var tp = method.GenericParameters?[0];
                                if (!method.HasBody) {
                                    continue;
                                }
                                {
                                    var bd = method.Body;
                                    var ins = bd.Instructions;
                                    var ilg = (ILProcessor)null;
                                    ilg = bd.GetILProcessor();
                                    var insa = ins.ToArray();
                                    for (var i = 0; insa.Length > i; ++i) {
                                        ilg.Remove(insa[i]);
                                    }
                                    {
                                        ilg.Append(ilg.Create(OpCodes.Sizeof, tp));
                                        ilg.Append(ilg.Create(OpCodes.Ret));
                                        ++modified;
                                    }
                                    if (null != ilg) {
                                        var ignored = 0;
                                    }
                                }
                            }
                        }
                    }
                    if (modified <= 0) {
                        return (int)ExitStatus.RequestFailed;
                    }
                    Console.Out.WriteLine($@"Modified: {modified}.");
                    var sss = (System.Reflection.StrongNameKeyPair)null;
                    try {
                        var keyfile = args?[1];
                        if (null != keyfile) {
                            sss = new System.Reflection.StrongNameKeyPair(File.ReadAllBytes(keyfile));
                        }
                    } catch (Exception) {
                    }

                    Console.Out.Write($@"Writing file: {fileName_Modified}... ");
                    var wp = new WriterParameters() { };
                    assembly.Write(fileName_Modified, wp);
                    Console.Out.WriteLine($@"Done.");
                    File.Replace(fileName_Modified, fileName_Original, fileName_Backup);
                    Console.Out.WriteLine($@"""{fileName_Original}"" -> ""{fileName_Backup}""");
                    Console.Out.WriteLine($@"""{fileName_Modified}"" -> ""{fileName_Original}""");
                    Console.Out.WriteLine(@"Done.");
                    return (int)ExitStatus.OK;
                } catch (Exception) {
                    return (int)ExitStatus.RequestFailed;
                }
                break;
            }
            return (int)ExitStatus.UserCanceled;
        }
    }
}
