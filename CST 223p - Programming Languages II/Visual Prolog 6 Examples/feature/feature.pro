/*****************************************************************************

		Copyright (c) Prolog Development Center

 Written by: Thomas Linder Puls
******************************************************************************/

implement feature
    open console % give non-qualified access to cConsole::write

    constants
        % untyped constant (only valid for numbers and strings)
        c1 = 17.
        % typed constant
        c2 : integer = 13.
 
    clauses
        run() :-
           finalizeDemo_class::demo(10000),
           memory::garbageCollect(),
           console::write("\nGarbage collection performed\n"),
           % use before declaration
           % nested function calls and expression evaluation
           writef("Nested evaluation : %\n", func(c2*func(c1))),
           finallyDemo(),
           %
           writef("Increase : %\n", increase()),
           writef("Increase : %\n", increase()),
           writef("Increase : %\n", increase()),
           writef("Increase : %\n", increase()),
           writef("Decrease : %\n", decrease()),
           writef("Decrease : %\n", decrease()),
           writef("Increase : %\n", increase()),
           writef("Increase : %\n", increase()),
           writef("Decrease : %\n", decrease()).

    class predicates
        % new function type syntax
        func : (integer In) -> integer Out procedure (i).
    clauses
        % new function clause syntax
        func(X) = 3*X :-
            X < 23,
            !.
        func(X) = 2*X.

    %=========================
    % finally
    %=========================
    class predicates
        finallyDemo : ().
        % finally takes two arguments, the second is executed after the first, no matter how the first part terminates:
        % - succeds
        % - fails
        % - raises an exception
    clauses
        finallyDemo() :-
            % first part succeds
             Part = "Success",
             traceFinally(before(), Part),
             % first part succeds
             finally(1=1, traceFinally(in(), Part)),
             traceFinally(after(), Part),
             fail.
        finallyDemo() :-
            % first part fails
             Part = "Fails",
             traceFinally(before(), Part),
             finally(1=0, traceFinally(in(), Part)),
             traceFinally(after(), Part),
             fail.
        finallyDemo() :-
            % first part raises an exception
             Part = "Raises exception",
             traceFinally(before(), Part),
             trap(
                 finally(common_Exception::raise_error(classInfo, predicate_name(), "Dummy"), traceFinally(in(), Part)),
                 TrapId,
                 % compound trap part
                 (writef("Exception trapped %\n", TrapId), exception::clearAll(), fail)),
             traceFinally(after(), Part),
             fail.
        finallyDemo().

    domains
        tracePoint = before(); in(); after().
    class predicates
        traceFinally : (tracePoint TracePoint, string Part) procedure(i,i).
    clauses
        traceFinally(TracePoint, Part) :-
            % writef accepts functor domains
            writef("Finally demo % : %\n", Part, TracePoint).

    %=========================
    % fact variables
    %=========================
    % single argumentd single facts have imperative "variable" syntax
    class facts
        counter : integer := 0.
    class predicates
        increase : () -> integer.
        decrease : () -> integer.
    clauses
        % return expression and output parameters are evaluated after the body!
        increase() = counter :-
            counter := counter+1.
        decrease() = counter :-
            counter := counter-1.

    constants
        className = "com/visual-prolog/demo6/feature/cFeature".
        classVersion = "Version 1.0".

    clauses
        classInfo(className, classVersion).
end implement feature

class finalizeDemo_class : object
    predicates
        % Create "Count" dead objects that the garbage collector can finalize
        demo : (unsigned Count).
end class finalizeDemo_class

implement finalizeDemo_class
    class facts
        created : unsigned := 0.
        finalized : unsigned := 0.
    facts
        id : unsigned.
    clauses
        new() :-
            created := created+1,
            id := created,
            trace("+").
    
    clauses
        finalize() :-
            finalized := finalized+1,
            trace("-").
    
    predicates
        trace : (string Mark) procedure (i).
    clauses
        trace(_Mark) :-
            0 = id mod 100,
            console::write(id),
            fail.
        trace(Mark) :-
            console::write(Mark).
    
    clauses
        demo(0) :-
            !,
            console::writef("\nFinalize demo ended, created = % finalized = %\n", created, finalized).
        demo(Count) :-
            _O = finalizeDemo_class::new(),
            demo(Count-1).
end implement finalizeDemo_class

goal
    mainExe::run(feature::run).

/*
several buildin features of VIP5.2 have been generalized such that user predicates have access to the features: 
 varying number of arguments (like for write) can be used by user predicates, e.g.:

predicates
    traceWrite : (...)
clauses
    traceWrite(...) :-
        TraceStream = getTraceStream:(),
        TraceStream:write("Trace begin\n"),
        TraceStream:write(...),
        TraceStream:write("Trace end\n").

goal
    traceWrite(" Hello Trace-reader, "X = ", 1, "\n").

"any-type" type, e.g.:

predicates
    myRead : () -> _ Term
clauses
    myRead() = Stream:read() :-
        Stream = getMyStream().


PFC io is stream based (as you can see in the examples above) 
PFC have string streams (an efficient way to construct strings, i.e. more efficient than using concat) 
PFC supports implementation of other kinds of streams, by providing stream support packages

file streams 
string streams 
console streams 
are all based on these support packages, and in the future sockets and other kinds of streams will also be implemented by means of these packages 

save/consult are stream based, so in future you can save a fact database in one end of a socket and consult it in the other end. 
(As I write this the status of save/consult for the release is not completely clear).
*/
