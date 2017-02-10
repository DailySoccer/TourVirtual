//
//  _MDPLiveMatchTeamStatModel.m
//  MDPClient
//
//  Created automatically with Mogenerator Templates.
//  Copyright (c) 2014 Microsoft. All rights reserved.
//

// DO NOT EDIT. This file is machine-generated and constantly overwritten.
// Make changes to MDPLiveMatchTeamStatModel.h instead.

@import CoreData;
#import "NSManagedObject+MDPManagedObject.h"

extern const struct MDPLiveMatchTeamStatModelAttributes {
	__unsafe_unretained NSString *extraFirstHalfValue;
	__unsafe_unretained NSString *extraSecondHalfValue;
	__unsafe_unretained NSString *firstHalfValue;
	__unsafe_unretained NSString *idLiveMatchTeamStat;
	__unsafe_unretained NSString *lastUpdateAt;
	__unsafe_unretained NSString *liveMatchTeamStatModelType;
	__unsafe_unretained NSString *recordType;
	__unsafe_unretained NSString *secondHalfValue;
	__unsafe_unretained NSString *value;
} MDPLiveMatchTeamStatModelAttributes;

extern const struct MDPLiveMatchTeamStatModelRelationships {
	__unsafe_unretained NSString *footballLiveMatchTeamStatisticsStats;
} MDPLiveMatchTeamStatModelRelationships;

@class MDPFootballLiveMatchTeamStatisticsModel;

@interface _MDPLiveMatchTeamStatModel : NSManagedObject

@property (nonatomic, strong) NSNumber* extraFirstHalfValue;

@property (atomic) int64_t extraFirstHalfValueValue;
- (int64_t)extraFirstHalfValueValue;
- (void)setExtraFirstHalfValueValue:(int64_t)value_;

//- (BOOL)validateExtraFirstHalfValue:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSNumber* extraSecondHalfValue;

@property (atomic) int64_t extraSecondHalfValueValue;
- (int64_t)extraSecondHalfValueValue;
- (void)setExtraSecondHalfValueValue:(int64_t)value_;

//- (BOOL)validateExtraSecondHalfValue:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSNumber* firstHalfValue;

@property (atomic) int64_t firstHalfValueValue;
- (int64_t)firstHalfValueValue;
- (void)setFirstHalfValueValue:(int64_t)value_;

//- (BOOL)validateFirstHalfValue:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* idLiveMatchTeamStat;

//- (BOOL)validateIdLiveMatchTeamStat:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSDate* lastUpdateAt;

//- (BOOL)validateLastUpdateAt:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* liveMatchTeamStatModelType;

//- (BOOL)validateLiveMatchTeamStatModelType:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* recordType;

//- (BOOL)validateRecordType:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSNumber* secondHalfValue;

@property (atomic) int64_t secondHalfValueValue;
- (int64_t)secondHalfValueValue;
- (void)setSecondHalfValueValue:(int64_t)value_;

//- (BOOL)validateSecondHalfValue:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSDecimalNumber* value;

//- (BOOL)validateValue:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) MDPFootballLiveMatchTeamStatisticsModel *footballLiveMatchTeamStatisticsStats;

//- (BOOL)validateFootballLiveMatchTeamStatisticsStats:(id*)value_ error:(NSError**)error_;

@end

@interface _MDPLiveMatchTeamStatModel (CoreDataGeneratedPrimitiveAccessors)

- (NSNumber*)primitiveExtraFirstHalfValue;
- (void)setPrimitiveExtraFirstHalfValue:(NSNumber*)value;

- (int64_t)primitiveExtraFirstHalfValueValue;
- (void)setPrimitiveExtraFirstHalfValueValue:(int64_t)value_;

- (NSNumber*)primitiveExtraSecondHalfValue;
- (void)setPrimitiveExtraSecondHalfValue:(NSNumber*)value;

- (int64_t)primitiveExtraSecondHalfValueValue;
- (void)setPrimitiveExtraSecondHalfValueValue:(int64_t)value_;

- (NSNumber*)primitiveFirstHalfValue;
- (void)setPrimitiveFirstHalfValue:(NSNumber*)value;

- (int64_t)primitiveFirstHalfValueValue;
- (void)setPrimitiveFirstHalfValueValue:(int64_t)value_;

- (NSString*)primitiveIdLiveMatchTeamStat;
- (void)setPrimitiveIdLiveMatchTeamStat:(NSString*)value;

- (NSDate*)primitiveLastUpdateAt;
- (void)setPrimitiveLastUpdateAt:(NSDate*)value;

- (NSString*)primitiveLiveMatchTeamStatModelType;
- (void)setPrimitiveLiveMatchTeamStatModelType:(NSString*)value;

- (NSString*)primitiveRecordType;
- (void)setPrimitiveRecordType:(NSString*)value;

- (NSNumber*)primitiveSecondHalfValue;
- (void)setPrimitiveSecondHalfValue:(NSNumber*)value;

- (int64_t)primitiveSecondHalfValueValue;
- (void)setPrimitiveSecondHalfValueValue:(int64_t)value_;

- (NSDecimalNumber*)primitiveValue;
- (void)setPrimitiveValue:(NSDecimalNumber*)value;

- (MDPFootballLiveMatchTeamStatisticsModel*)primitiveFootballLiveMatchTeamStatisticsStats;
- (void)setPrimitiveFootballLiveMatchTeamStatisticsStats:(MDPFootballLiveMatchTeamStatisticsModel*)value;

@end
