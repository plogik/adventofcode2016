import Data.Char
import Data.List

rotate :: Int -> Char -> Char
rotate _ '-' = ' '
rotate 0 c = c
rotate n 'z' = rotate (n - 1) 'a'
rotate n c = rotate (n - 1) (chr $ (ord c) + 1)

encryptedName x = init $ takeWhile (not . isDigit) x

sectorId x = read $ filter isDigit x :: Int

realname :: String -> String
realname x = go (sectorId x) (encryptedName x)
    where go c x = map (rotate c) x

findNorthPoleRoomSectorId :: [String] -> Int
findNorthPoleRoomSectorId (x:xs) = 
    case (isPrefixOf "north" $ realname x) of 
        True -> sectorId x
        _ -> findNorthPoleRoomSectorId xs


main = do
    input <- readFile "input.txt"
    let theId = findNorthPoleRoomSectorId $ lines input
    putStrLn $ "Sector id: " ++ show theId

