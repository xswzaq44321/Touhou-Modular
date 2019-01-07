local laser, radiate

minion = {
	delay = 0,
	a = 0,
	way = 1,
	obj,
	baseUpDate = function(tab)
		tab.delay = tab.delay + timer.deltaTime
		if (tab.death) then
			tab.upDate = function()
				-- nothing
			end
		end
	end,
	upDate = function(tab)
		-- laser(tab)
	end
}

laser = function(tab)
	if (tab.delay >= 0.2) then
		local x, y, z = tab.my_position()
		tab.laser("red_laser", x, y, z, tab.player_direction() + math.random(-15, 15), 1)
		tab.delay = 0
	end
end