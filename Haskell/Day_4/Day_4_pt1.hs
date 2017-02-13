import Data.Char
import Data.List

-- Will produce ["ooo","aa","rr","e","l","m","n","t"] on input "not-a-real-room-404[oarel]"
groupAndOrder :: String -> [String]
groupAndOrder x = reverse . sortOn length $ group . reverse . sort $ filter isAlpha $ takeWhile (/='[') x

-- Will produce "oarel" on input ["ooo","aa","rr","e","l","m","n","t"]
proposedChecksum :: String -> String
proposedChecksum x = take 5 . map head $ groupAndOrder x

realChecksum :: String -> String
realChecksum x  = tail . takeWhile (/= ']') $ dropWhile (/='[') x

checksumOrZero :: String -> Int
checksumOrZero x = 
    case isReal x of True -> read $ filter isDigit x
                     False -> 0
        where isReal n = proposedChecksum n == realChecksum n

main = do
    input <- readFile "input.txt"
    let sum = foldl (\acc x -> acc + (checksumOrZero x)) 0 $ lines input
    putStrLn $ "Sum: " ++ show sum