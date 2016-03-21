(DEFINE (ADDER n)
  (+ 1 (ADDER n))
)

(DEFINE (atom? x)
  (and (not (pair? x)) (not (null? x)))
)

(ADDER 6)

21