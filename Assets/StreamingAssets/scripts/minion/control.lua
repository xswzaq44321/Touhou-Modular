local laser, radiate

minion = {
	a = 0,
	way = 1,
	pid = -1,
	obj,
	delay = 0,
	atkCount = 0,
	baseUpDate = function(tab)
		tab.delay = tab.delay + timer.deltaTime
		if (tab.death) then
			tab.upDate = function()
				-- nothing
			end
		end
	end,
	upDate = function(tab)
	end
}

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