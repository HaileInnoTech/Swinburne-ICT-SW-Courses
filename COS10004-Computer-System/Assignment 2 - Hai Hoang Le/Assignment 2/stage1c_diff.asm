; function stage1c_diff
; returns the difference between the max and min value out of three arguments passed in
; Arguments:
; r0 - first value
; r1 - second value
; r2 - third value
; Returns result in r0 register

stage1c_diff:
        push {r8, r9}
        ; Getting min
        push {lr, r0-r2}
             bl stage1a_min
             mov r8, r0         ; mov result to r11
        pop {lr, r0-r2}
        ; Getting max
        push {lr, r0-r2}
             bl stage1b_max
             mov r9, r0         ; mov result to r12
        pop {lr, r0-r2}
        sub r0, r9, r8
        pop {r8, r9}
bx lr