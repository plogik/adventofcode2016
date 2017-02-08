
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

rowsToCols :: [Triangle] -> [Triangle]
rowsToCols [] = []
rowsToCols [(x1, y1, z1), (x2, y2, z2), (x3, y3, z3)] = [(x1, x2, x3), (y1, y2, y3), (z1, z2, z3)]

rightTriangleCount :: [Triangle] -> Int
rightTriangleCount [] = 0
rightTriangleCount xs =  length $ filter isRightTriangle xs

testTriangles' :: [Triangle] -> Int
testTriangles' ts = go ts 0
    where go [] n = n
          go (x:y:z:xs) n = go xs (n + (rightTriangleCount . rowsToCols $ [x,y,z]))

main = do
    input <- readFile "input.txt"
    let n = testTriangles' . map parseTriangle $ lines input
    putStrLn $ "Correct # triangles:" ++ show n
