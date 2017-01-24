import Data.Maybe

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

move :: Point -> Direction -> Steps -> [Point]
move (x, y) N s = [(x, y + n) | n <- [1..s]]
move (x, y) W s = [(x - n, y) | n <- [1..s]]
move (x, y) S s = [(x, y - n) | n <- [1..s]]
move (x, y) E s = [(x + n, y) | n <- [1..s]]

parseInput :: String -> [(Turn, Steps)]
parseInput s = map (\(x:xs) -> (read [x] :: Turn, read xs :: Steps)) $ 
            map (takeWhile (/=',')) $ words s

moveAll :: Direction -> Point -> [(Turn, Steps)] -> [Point] -> [Point]
moveAll _ _ [] ps = ps -- no more steps
moveAll d p ((x,y):xs) ps = do
    let nd = newDirection d x
        nps = move p nd y
    moveAll nd (last nps) xs (ps ++ nps)

firstDup :: [Point] -> Maybe Point
firstDup [] = Nothing
firstDup (x:xs)
    | x `elem` xs = Just x
    | otherwise = firstDup xs

distance :: Point -> Int
distance = (\(x, y) -> (abs x) + (abs y))

-- Assumes there is a duplicate
main = do
    input <- readFile "input.txt"
    let maybeDup = firstDup $  moveAll N (0,0) (parseInput input) [(0, 0)]
    putStrLn $ "First dup: " ++ show (distance (fromJust maybeDup))

