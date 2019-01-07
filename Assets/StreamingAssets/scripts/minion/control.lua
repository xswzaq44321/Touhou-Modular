minion = {
	delay = 0,
	a = 0,
	way = 1,
	obj,

	baseUpDate = function()
		boss.delay = boss.delay + timer.deltaTime
		if (boss.death) then
			boss.upDate = function()
				-- nothing
			end
		end
	end,
	upDate = function()
	end
}