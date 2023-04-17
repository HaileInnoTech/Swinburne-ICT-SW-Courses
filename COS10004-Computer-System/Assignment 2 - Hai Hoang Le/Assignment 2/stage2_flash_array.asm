; function stage2_flash_array
; flashes the contents of array given
; Arguments:
; r0 - BASE address of peripherals
; r1 - size of array
; r2 - array to flash
; Function returns nothing

stage2_flash_array:
        push {r8}

        forloop:
                ldr r8, [r2], #4
                push {lr, r1-r2}
                     mov r1, r8
                     mov r2, $45000  ; pause time between flashes r10
                     bl FLASH
                     mov r1, $130000 ; pause time
                     bl PAUSE
                pop {lr, r1-r2}
                sub r1, #1
                cmp r1, #0
        bgt forloop

        pop {r8}
bx lr