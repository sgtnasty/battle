#!/usr/bin/ruby -rubygems
require 'rainbow'
puts "this is red".foreground(:red) + " and " + "this on yellow bg".background(:yellow) + " and " + "even bright underlined!".underline.bright