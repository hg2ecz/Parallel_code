#!/usr/bin/luajit

globi = 3000000
primct = 0

function primtest()
    while true do
	local i=globi
	globi=globi-1

	if i < 2 then
	    return -- end
	end
	local prim = true
	local sqi = math.floor(math.sqrt(i))
	for j=2,sqi do
	    if i%j == 0 then
		prim=False
		break
	    end
	end
	if prim == true then
	    primct=primct+1
	end
    end
end

primtest()
print (primct)
