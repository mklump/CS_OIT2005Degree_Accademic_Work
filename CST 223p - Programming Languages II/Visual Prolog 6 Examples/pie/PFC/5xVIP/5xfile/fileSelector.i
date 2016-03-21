%Declaration of FILE domain.
%Don't change standard functors
interface fileSelector
    domains
        file =
            keyboard();%standard functor
            screen();  %standard functor
            stdin();   %standard functor
            stdout();  %standard functor
            stderr();  %standard functor
            temp();
            seeing();
            telling().
end interface