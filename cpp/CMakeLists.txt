cmake_minimum_required(VERSION 3.15)

set(LINKS_PLATFORM_EXTRA_FLAGS "" CACHE STRING "Extra compiler flags")

project(Platform.Ranges)
set(CMAKE_RUNTIME_OUTPUT_DIRECTORY ${CMAKE_BINARY_DIR}/bin)

# Set compiler flags for x86_64 architecture
if(CMAKE_SYSTEM_PROCESSOR STREQUAL "x86_64")
    set(CMAKE_CXX_FLAGS "${CMAKE_CXX_FLAGS} -march=haswell")
endif()

# Set compiler flags for armv7 architecture
if(CMAKE_SYSTEM_PROCESSOR STREQUAL "armv7")
    set(CMAKE_CXX_FLAGS "${CMAKE_CXX_FLAGS} -march=armv7")
endif()

# Set compiler flags for armv8 architecture
if(CMAKE_SYSTEM_PROCESSOR STREQUAL "armv8")
    set(CMAKE_CXX_FLAGS "${CMAKE_CXX_FLAGS} -march=armv8-a")
endif()

find_package(Platform.Converters REQUIRED)
find_package(Platform.Exceptions REQUIRED)
find_package(Platform.Hashing REQUIRED CONFIG)
find_package(GTest REQUIRED)

add_library(${PROJECT_NAME}.Library INTERFACE)
target_include_directories(${PROJECT_NAME}.Library INTERFACE ${PROJECT_NAME})
target_link_libraries(${PROJECT_NAME}.Library INTERFACE Platform.Converters::Platform.Converters)
target_link_libraries(${PROJECT_NAME}.Library INTERFACE Platform.Exceptions::Platform.Exceptions)
target_link_libraries(${PROJECT_NAME}.Library INTERFACE Platform.Hashing::Platform.Hashing)
#target_compile_options(${PROJECT_NAME}.Library INTERFACE ${LINKS_PLATFORM_EXTRA_FLAGS})


if(${LINKS_PLATFORM_TESTS})
    add_executable(${PROJECT_NAME}.Tests ${PROJECT_NAME}.Tests/AllTests.cpp)
    target_link_libraries(${PROJECT_NAME}.Tests PRIVATE ${PROJECT_NAME}.Library)
    target_link_libraries(${PROJECT_NAME}.Tests PRIVATE GTest::gtest)
    target_link_libraries(${PROJECT_NAME}.Tests PRIVATE GTest::gtest_main)
    set_target_properties(${PROJECT_NAME}.Tests PROPERTIES CXX_STANDARD 20)
endif()
