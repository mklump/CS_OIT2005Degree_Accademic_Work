    count(100).

    loop:-count(X),
        X>0,
        !,
        NewX = X - 1,
        retract(count(X)),
        assert(count(NewX)),
        loop().
    loop:-write("End of loop").