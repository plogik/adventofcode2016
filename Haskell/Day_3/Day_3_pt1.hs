import System.CPUTime
import Text.Printf

type Triangle =  (Int, Int, Int)

isRightTriangle :: Triangle -> Bool
isRightTriangle (x, y, z) =
    x < (y + z) &&
    y < (x + z) &&
    z < (x + y)

toTriangle :: [Int] -> Triangle
toTriangle [x, y, z] = (x, y, z)

parseTriangle :: String -> Triangle
parseTriangle n = toTriangle $ map (read::String->Int) (words n)

-- This function is not used
testTriangles :: [String] -> Int
testTriangles s = go s 0 
    where go [] n = n
          go (x:xs) n = 
            if isRightTriangle $ parseTriangle x 
                then go xs (n + 1)
                else go xs n


main = do
    start <- getCPUTime
    input <- readFile "input.txt"
    --let n = testTriangles $ lines input
    let n = length . filter isRightTriangle . map parseTriangle $ lines input
    end <- getCPUTime
    let diff = (fromIntegral (end - start)) / (10^12)
    printf "# correct triangles: %d, time: %0.5fs\n" (n::Int) (diff :: Double)
