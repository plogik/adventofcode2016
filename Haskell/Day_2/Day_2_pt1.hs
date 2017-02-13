import Data.Char -- for intToDigit

move :: Int -> Char -> Int
move curr d
   | d == 'U' =
        case curr of 4 -> 1
                     5 -> 2
                     6 -> 3
                     7 -> 4
                     8 -> 5
                     9 -> 6
                     _ -> curr
    | d == 'D' =
        case curr of 1 -> 4
                     2 -> 5
                     3 -> 6
                     4 -> 7
                     5 -> 8
                     6 -> 9
                     _ -> curr
   | d == 'L' =
        case curr of 2 -> 1
                     3 -> 2
                     5 -> 4
                     6 -> 5
                     8 -> 7
                     9 -> 8
                     _ -> curr 
    | d == 'R' =
        case curr of 1 -> 2
                     2 -> 3
                     4 -> 5
                     5 -> 6
                     7 -> 8
                     8 -> 9
                     _ -> curr

getButton :: Int -> String -> Int
getButton curr [] = curr
getButton curr (x:xs) = getButton (move curr x) xs

getCode :: [String] -> [Int]
getCode xs = tail $ scanl getButton 5 xs


main = do
    input <- readFile "input.txt"
    let result = getCode $ lines input
    print $ map intToDigit result

