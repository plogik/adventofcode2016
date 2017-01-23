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

input = "R4, R4, L1, R3, L5, R2, R5, R1, L4, R3, L5, R2, L3, L4, L3, R1, R5, R1, L3, L1, R3, L1, R2, R2, L2, R5, L3, L4, R4, R4, R2, L4, L1, R5, L1, L4, R4, L1, R1, L2, R5, L2, L3, R2, R1, L194, R2, L4, R49, R1, R3, L5, L4, L1, R4, R2, R1, L5, R3, L5, L4, R4, R4, L2, L3, R78, L5, R4, R191, R4, R3, R1, L2, R1, R3, L1, R3, R4, R2, L2, R1, R4, L5, R2, L2, L4, L2, R1, R2, L3, R5, R2, L3, L3, R3, L1, L1, R5, L4, L4, L2, R5, R1, R4, L3, L5, L4, R5, L4, R5, R4, L3, L2, L5, R4, R3, L3, R1, L5, R5, R1, L3, R2, L5, R5, L3, R1, R4, L5, R4, R2, R3, L4, L5, R3, R4, L5, L5, R4, L4, L4, R1, R5, R3, L1, L4, L3, L4, R1, L5, L1, R2, R2, R4, R4, L5, R4, R1, L1, L1, L3, L5, L2, R4, L3, L5, L4, L1, R3"
pt1 = distance $ moveAll N (0,0) $ parseInput input
    