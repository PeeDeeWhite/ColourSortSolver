﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ColourSortSolver.Properties {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "17.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class Resources {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Resources() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("ColourSortSolver.Properties.Resources", typeof(Resources).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The file does not exist..
        /// </summary>
        internal static string FileDoesNotExist {
            get {
                return ResourceManager.GetString("FileDoesNotExist", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Please provide a valid file name as an argument..
        /// </summary>
        internal static string InvalidFilename {
            get {
                return ResourceManager.GetString("InvalidFilename", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Moves:.
        /// </summary>
        internal static string Moves {
            get {
                return ResourceManager.GetString("Moves", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Puzzle container must all have a minimum size of 1.
        /// </summary>
        internal static string PuzzleContainerMinimumSize {
            get {
                return ResourceManager.GetString("PuzzleContainerMinimumSize", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to All Puzzle containers are empty.
        /// </summary>
        internal static string PuzzleContainersAreEmpty {
            get {
                return ResourceManager.GetString("PuzzleContainersAreEmpty", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Puzzle Containers must have sequential positions.
        /// </summary>
        internal static string PuzzleContainersPositionNotSequential {
            get {
                return ResourceManager.GetString("PuzzleContainersPositionNotSequential", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Puzzle containers are of varying sizes.
        /// </summary>
        internal static string PuzzleContainersVaryingSizes {
            get {
                return ResourceManager.GetString("PuzzleContainersVaryingSizes", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Failed to find a solution to the puzzle.
        /// </summary>
        internal static string PuzzleFailedToSolve {
            get {
                return ResourceManager.GetString("PuzzleFailedToSolve", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Puzzle is invalid due to the following errors:.
        /// </summary>
        internal static string PuzzleInvalidWithErrors {
            get {
                return ResourceManager.GetString("PuzzleInvalidWithErrors", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Puzzle Is Empty.
        /// </summary>
        internal static string PuzzleIsEmpty {
            get {
                return ResourceManager.GetString("PuzzleIsEmpty", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Puzzle solved: {0} in {1} moves.
        /// </summary>
        internal static string PuzzleSolvedMoves {
            get {
                return ResourceManager.GetString("PuzzleSolvedMoves", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Puzzle is valid..
        /// </summary>
        internal static string PuzzleValid {
            get {
                return ResourceManager.GetString("PuzzleValid", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Unknown colour.
        /// </summary>
        internal static string Unknowncolour {
            get {
                return ResourceManager.GetString("Unknowncolour", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Each colour must be present {0} times.
        /// </summary>
        internal static string WrongNumberOfColours {
            get {
                return ResourceManager.GetString("WrongNumberOfColours", resourceCulture);
            }
        }
    }
}
