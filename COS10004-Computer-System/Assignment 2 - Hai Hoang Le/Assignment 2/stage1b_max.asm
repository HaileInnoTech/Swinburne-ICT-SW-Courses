; function stage1b_max
; returns the maximum value out of three arguments passed in
; Arguments:
; r0 - first value
; r1 - second value
; r2 - third value
; Returns result in r0 register

stage1b_max:
     cmp r0, r1                 ;compare
        bgt maxa
            mov r0, r1
        maxa:
    cmp r0, r2
               bgt maxb
                   mov r0, r2
               maxb:
bx lr

