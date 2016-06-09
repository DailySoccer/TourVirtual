//
//  _MDPTimelineModel.m
//  MDPClient
//
//  Created automatically with Mogenerator Templates.
//  Copyright (c) 2014 Microsoft. All rights reserved.
//

// DO NOT EDIT. This file is machine-generated and constantly overwritten.
// Make changes to MDPTimelineModel.h instead.

@import CoreData;
#import "NSManagedObject+MDPManagedObject.h"

extern const struct MDPTimelineModelAttributes {
	__unsafe_unretained NSString *competition;
	__unsafe_unretained NSString *idCompetition;
	__unsafe_unretained NSString *idMatch;
	__unsafe_unretained NSString *idSeason;
	__unsafe_unretained NSString *language;
	__unsafe_unretained NSString *lastUpdateAt;
	__unsafe_unretained NSString *season;
	__unsafe_unretained NSString *sportType;
} MDPTimelineModelAttributes;

extern const struct MDPTimelineModelRelationships {
	__unsafe_unretained NSString *matchEvents;
} MDPTimelineModelRelationships;

@class MDPMatchEventModel;

@interface _MDPTimelineModel : NSManagedObject

@property (nonatomic, strong) NSString* competition;

//- (BOOL)validateCompetition:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* idCompetition;

//- (BOOL)validateIdCompetition:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* idMatch;

//- (BOOL)validateIdMatch:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* idSeason;

//- (BOOL)validateIdSeason:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* language;

//- (BOOL)validateLanguage:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSDate* lastUpdateAt;

//- (BOOL)validateLastUpdateAt:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* season;

//- (BOOL)validateSeason:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSNumber* sportType;

@property (atomic) uint16_t sportTypeValue;
- (uint16_t)sportTypeValue;
- (void)setSportTypeValue:(uint16_t)value_;

//- (BOOL)validateSportType:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSOrderedSet *matchEvents;

- (NSMutableOrderedSet*)matchEventsSet;

@end

@interface _MDPTimelineModel (MatchEventsCoreDataGeneratedAccessors)
- (void)addMatchEvents:(NSOrderedSet*)value_;
- (void)removeMatchEvents:(NSOrderedSet*)value_;
- (void)addMatchEventsObject:(MDPMatchEventModel*)value_;
- (void)removeMatchEventsObject:(MDPMatchEventModel*)value_;
@end

@interface _MDPTimelineModel (CoreDataGeneratedPrimitiveAccessors)

- (NSString*)primitiveCompetition;
- (void)setPrimitiveCompetition:(NSString*)value;

- (NSString*)primitiveIdCompetition;
- (void)setPrimitiveIdCompetition:(NSString*)value;

- (NSString*)primitiveIdMatch;
- (void)setPrimitiveIdMatch:(NSString*)value;

- (NSString*)primitiveIdSeason;
- (void)setPrimitiveIdSeason:(NSString*)value;

- (NSString*)primitiveLanguage;
- (void)setPrimitiveLanguage:(NSString*)value;

- (NSDate*)primitiveLastUpdateAt;
- (void)setPrimitiveLastUpdateAt:(NSDate*)value;

- (NSString*)primitiveSeason;
- (void)setPrimitiveSeason:(NSString*)value;

- (NSNumber*)primitiveSportType;
- (void)setPrimitiveSportType:(NSNumber*)value;

- (uint16_t)primitiveSportTypeValue;
- (void)setPrimitiveSportTypeValue:(uint16_t)value_;

- (NSMutableOrderedSet*)primitiveMatchEvents;
- (void)setPrimitiveMatchEvents:(NSMutableOrderedSet*)value;

@end
