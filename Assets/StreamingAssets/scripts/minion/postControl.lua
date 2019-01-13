local radiate

radiate = function(tabl)
	if (tabl.delay > 3) then
		tabl.a = tabl.a + 0.5
		if (tabl.pid == -1 and tabl.atkCount < 3) then
			tabl.pid =
				setInterval(
				function()
					tabl.radiate("pink_load", "pink_circle_small", 18, 4.4, 0, 0)
				end,
				0.2
			)
		end
		if (tabl.delay > 4.5) then
			tabl.atkCount = tabl.atkCount + 1
			clearInterval(tabl.pid)
			tabl.pid = -1
			tabl.delay = 0
			tabl.a = 0
		end
	end
end

laser = function(tab)
	if (tab.delay >= 0.2) then
		local x, y, z = tab.my_position()
		tab.laser("red_laser", x, y, z, tab.player_direction() + math.random(-15, 15), 1)
		tab.delay = 0
	end
end

moveRight = function(tabl)
	tabl.move_straight(0, 1, 3)
end

moveLeft = function(tabl)
	tabl.move_straight(180, 1, 3)
end

local flag1 = 1
local flag2 = 1

minions[1].upDate = function(tab)
	if (flag1 == 1) then
		tab.move_straight(180, 5, 100)
		flag1 = 2
	elseif (flag1 == 2) then
		if (tab.delay >= 1) then
			tab.move_straight(0, 5, 2)
			flag1 = 3
		end
	elseif (flag1 == 3) then
		radiate(tab)
		if (tab.atkCount >= 3) then
			flag1 = 4
		end
	elseif (flag1 == 4) then
		tab.move_straight(180, 5, 3)
		flag1 = 5
	end
end

minions[2].upDate = function(tab)
	if (flag2 == 1) then
		tab.move_straight(0, 5, 100)
		flag2 = 2
	elseif (flag2 == 2) then
		if (tab.delay >= 1) then
			tab.move_straight(180, 5, 2)
			flag2 = 3
		end
	elseif (flag2 == 3) then
		radiate(tab)
		if (tab.atkCount >= 3) then
			flag2 = 4
		end
	elseif (flag2 == 4) then
		tab.move_straight(0, 5, 3)
		falg2 = 5
	end
end
