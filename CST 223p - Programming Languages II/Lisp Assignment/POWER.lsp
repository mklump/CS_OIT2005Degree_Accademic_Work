(DEFINE (POW x n)
  (* x (POW x n))
)

(POW 3 3)

9