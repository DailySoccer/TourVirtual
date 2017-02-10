//
//  _MDPLiveMatchTeamModel.m
//  MDPClient
//
//  Created automatically with Mogenerator Templates.
//  Copyright (c) 2014 Microsoft. All rights reserved.
//

// DO NOT EDIT. This file is machine-generated and constantly overwritten.
// Make changes to MDPLiveMatchTeamModel.h instead.

@import CoreData;
#import "NSManagedObject+MDPManagedObject.h"

extern const struct MDPLiveMatchTeamModelAttributes {
	__unsafe_unretained NSString *badgeThumbnailUrl;
	__unsafe_unretained NSString *badgeUrl;
	__unsafe_unretained NSString *idTeam;
	__unsafe_unretained NSString *lastUpdateAt;
	__unsafe_unretained NSString *score;
	__unsafe_unretained NSString *teamName;
} MDPLiveMatchTeamModelAttributes;

extern const struct MDPLiveMatchTeamModelRelationships {
	__unsafe_unretained NSString *footballLiveMatchTeamStatisticsTeam;
	__unsafe_unretained NSString *matchAwayTeam;
	__unsafe_unretained NSString *matchHomeTeam;
} MDPLiveMatchTeamModelRelationships;

@class MDPFootballLiveMatchTeamStatisticsModel;
@class MDPMatchModel;
@class MDPMatchModel;

@interface _MDPLiveMatchTeamModel : NSManagedObject

@property (nonatomic, strong) NSString* badgeThumbnailUrl;

//- (BOOL)validateBadgeThumbnailUrl:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* badgeUrl;

//- (BOOL)validateBadgeUrl:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* idTeam;

//- (BOOL)validateIdTeam:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSDate* lastUpdateAt;

//- (BOOL)validateLastUpdateAt:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSNumber* score;

@property (atomic) int64_t scoreValue;
- (int64_t)scoreValue;
- (void)setScoreValue:(int64_t)value_;

//- (BOOL)validateScore:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* teamName;

//- (BOOL)validateTeamName:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) MDPFootballLiveMatchTeamStatisticsModel *footballLiveMatchTeamStatisticsTeam;

//- (BOOL)validateFootballLiveMatchTeamStatisticsTeam:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) MDPMatchModel *matchAwayTeam;

//- (BOOL)validateMatchAwayTeam:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) MDPMatchModel *matchHomeTeam;

//- (BOOL)validateMatchHomeTeam:(id*)value_ error:(NSError**)error_;

@end

@interface _MDPLiveMatchTeamModel (CoreDataGeneratedPrimitiveAccessors)

- (NSString*)primitiveBadgeThumbnailUrl;
- (void)setPrimitiveBadgeThumbnailUrl:(NSString*)value;

- (NSString*)primitiveBadgeUrl;
- (void)setPrimitiveBadgeUrl:(NSString*)value;

- (NSString*)primitiveIdTeam;
- (void)setPrimitiveIdTeam:(NSString*)value;

- (NSDate*)primitiveLastUpdateAt;
- (void)setPrimitiveLastUpdateAt:(NSDate*)value;

- (NSNumber*)primitiveScore;
- (void)setPrimitiveScore:(NSNumber*)value;

- (int64_t)primitiveScoreValue;
- (void)setPrimitiveScoreValue:(int64_t)value_;

- (NSString*)primitiveTeamName;
- (void)setPrimitiveTeamName:(NSString*)value;

- (MDPFootballLiveMatchTeamStatisticsModel*)primitiveFootballLiveMatchTeamStatisticsTeam;
- (void)setPrimitiveFootballLiveMatchTeamStatisticsTeam:(MDPFootballLiveMatchTeamStatisticsModel*)value;

- (MDPMatchModel*)primitiveMatchAwayTeam;
- (void)setPrimitiveMatchAwayTeam:(MDPMatchModel*)value;

- (MDPMatchModel*)primitiveMatchHomeTeam;
- (void)setPrimitiveMatchHomeTeam:(MDPMatchModel*)value;

@end
