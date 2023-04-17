; function stage1a_min
; returns the minimum value out of three arguments passed in
; Arguments:
; r0 - first value
; r1 - second value
; r2 - third value
; Returns result in r0 register

stage1a_min:
     cmp r0, r1                    ;compare r0 and r1  (subtract r0 and r1)
        bls mina                   ;if r0 <= r1 then run this, if not will skip
            mov r0, r1             ;move the data from r0, r1
        mina:
     cmp r0, r2
                bls minb
                    mov r0, r2
                minb:
bx lr

