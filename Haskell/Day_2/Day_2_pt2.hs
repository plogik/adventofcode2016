import Data.Char

move :: Char -> Char -> Char
move '1' 'D' = '3'
move '2' 'D' = '6'
move '2' 'R' = '3'
move '3' 'U' = '1'
move '3' 'R' = '4'
move '3' 'D' = '7'
move '3' 'L' = '2'
move '4' 'D' = '8'
move '4' 'L' = '3'
move '5' 'R' = '6'
move '6' 'U' = '2'
move '6' 'R' = '7'
move '6' 'D' = 'A'
move '6' 'L' = '5'
move '7' 'U' = '3'
move '7' 'R' = '8'
move '7' 'D' = 'B'
move '7' 'L' = '6'
move '8' 'U' = '4'
move '8' 'R' = '9'
move '8' 'D' = 'C'
move '8' 'L' = '7'
move '9' 'L' = '8'
move 'A' 'U' = '6'
move 'A' 'R' = 'B'
move 'B' 'U' = '7'
move 'B' 'R' = 'C'
move 'B' 'D' = 'D'
move 'B' 'L' = 'A'
move 'C' 'U' = '8'
move 'C' 'L' = 'B'
move 'D' 'U' = 'B'
move c _ = c

getButton :: Char -> String -> Char
getButton curr [] = curr
getButton curr (x:xs) = getButton (move curr x) xs

getCode :: [String] -> [Char]
getCode xs = tail . scanl getButton '5' $ xs

main = do
    input <- readFile "input.txt"
    let result = getCode $ lines input
    print result

