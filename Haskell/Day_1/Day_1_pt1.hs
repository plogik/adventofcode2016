data Direction = N | E | S | W deriving (Show, Eq, Ord)
data Turn = L | R deriving (Read, Show, Eq, Ord)

type Point = (Int, Int)
type Steps = Int

newDirection :: Direction -> Turn -> Direction
newDirection N L = W
newDirection N R = E
newDirection E L = N
newDirection E R = S
newDirection S L = E
newDirection S R = W
newDirection W L = S
newDirection W R = N

move :: Point -> Direction -> Steps -> Point
move (x, y) N s = (x, y + s)
move (x, y) W s = (x - s, y)
move (x, y) S s = (x, y - s)
move (x, y) E s = (x + s, y)

parseInput :: String -> [(Turn, Steps)]
parseInput s = map (\(x:xs) -> (read [x] :: Turn, read xs :: Steps)) $ 
            map (takeWhile (/=',')) $ words s

moveAll :: Direction -> Point -> [(Turn, Steps)] -> Point
moveAll _ p [] = p -- no more steps, whe're there!
moveAll d p (x:xs) = do
    let nd = newDirection d (fst x)
    moveAll nd (move p nd (snd x)) xs

distance :: Point -> Int
distance = (\(x, y) -> (abs x) + (abs y))

pt1 :: String -> Int
pt1 s = distance $ moveAll N (0,0) $ parseInput s
    
main = do
    input <- readFile "input.txt"
    putStrLn $ "Distance: " ++ show (pt1 input)