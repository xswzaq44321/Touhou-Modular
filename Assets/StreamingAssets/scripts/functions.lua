--[[
    *** NOTICE ***
    PLEASE DO NOT TOUCH THIS FILE!!! OR THE PROGRAM MIGHT NOT WORKING CORRECTLY.
]]
timer = {}
updatelist = {}

local oldRequire = require
require = function(module)
    package.loaded[module] = nil
    return oldRequire(module)
end

function deepcopy(orig)
    local orig_type = type(orig)
    local copy
    if orig_type == "table" then
        copy = {}
        for orig_key, orig_value in next, orig, nil do
            copy[deepcopy(orig_key)] = deepcopy(orig_value)
        end
        setmetatable(copy, deepcopy(getmetatable(orig)))
    else -- number, string, boolean, etc
        copy = orig
    end
    return copy
end

function setInterval(func, time)
    local count = 0
    local pid = 0
    while (updatelist[pid] ~= nil) do
        pid = math.random(0, 10000)
    end
    updatelist[pid] = function()
        count = count + timer.deltaTime
        if (count >= time) then
            count = 0
            return true, func
        else
            return false, func
        end
    end
    return pid
end

function clearInterval(pid)
    updatelist[pid] = nil
end