isRightTriangle :: (Ord a, Num a) => (a, a, a) -> Bool
isRightTriangle (x, y, z) =
    (x < (y + z)) &&
    (y < (x + z)) &&
    (z < (x + y))

toTuple :: [Int] -> (Int, Int, Int)
toTuple [x, y, z] = (x, y, z)

parseTriangle :: String -> (Int, Int, Int)
parseTriangle n = toTuple $ map (read::String->Int) (words n)

testTriangles :: [String] -> Int
testTriangles s = go s 0 
    where go [] n = n
          go (x:xs) n = 
            if isRightTriangle $ parseTriangle x 
                then go xs (n + 1) 
                else go xs n


main = do
    input <- readFile "input.txt"
    let n = testTriangles $ lines input
    putStrLn $ "Correct # triangles:" ++ show n