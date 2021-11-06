cmake_minimum_required(VERSION 3.15)

set(LINKS_PLATFORM_EXTRA_FLAGS "" CACHE STRING "Extra compiler flags")

project(Platform.Ranges)
include(${CMAKE_BINARY_DIR}/conanbuildinfo.cmake)
conan_basic_setup(TARGETS)

list(APPEND LINKS_PLATFORM_EXTRA_FLAGS ${CONAN_USER_PLATFORM.HASHING_suggested_flags})

add_library(${PROJECT_NAME}.Library INTERFACE)
target_include_directories(${PROJECT_NAME}.Library INTERFACE ${PROJECT_NAME})
target_link_libraries(${PROJECT_NAME}.Library INTERFACE CONAN_PKG::platform.converters)
target_link_libraries(${PROJECT_NAME}.Library INTERFACE CONAN_PKG::platform.exceptions)
target_link_libraries(${PROJECT_NAME}.Library INTERFACE CONAN_PKG::platform.hashing)
target_compile_options(${PROJECT_NAME}.Library INTERFACE ${LINKS_PLATFORM_EXTRA_FLAGS})

add_executable(${PROJECT_NAME}.Tests ${PROJECT_NAME}.Tests/AllTests.cpp)
target_link_libraries(${PROJECT_NAME}.Tests PRIVATE ${PROJECT_NAME}.Library)
target_link_libraries(${PROJECT_NAME}.Tests PRIVATE CONAN_PKG::gtest)
set_target_properties(${PROJECT_NAME}.Tests PROPERTIES CXX_STANDARD 20)
