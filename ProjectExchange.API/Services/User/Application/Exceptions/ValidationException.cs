using System;
using System.Collections.Generic;
using System.Linq;
using FluentValidation.Results;

namespace Application.Exceptions {
    public class ValidationException : ApplicationException {
        public IDictionary<string, string[]> Errors { get; }
        public ValidationException () : base ("One or more validaton failures have occured.") { Errors = new Dictionary<string, string[]> (); }
        public ValidationException (IEnumerable<ValidationFailure> failures) : this () {
            Errors = failures.GroupBy (e => e.PropertyName, e => e.ErrorMessage).ToDictionary (failureGroup => failureGroup.Key, failureGroup => failureGroup.ToArray ());
        }
    }
}