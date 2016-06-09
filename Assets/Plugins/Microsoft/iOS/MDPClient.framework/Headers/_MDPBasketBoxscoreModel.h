//
//  _MDPBasketBoxscoreModel.m
//  MDPClient
//
//  Created automatically with Mogenerator Templates.
//  Copyright (c) 2014 Microsoft. All rights reserved.
//

// DO NOT EDIT. This file is machine-generated and constantly overwritten.
// Make changes to MDPBasketBoxscoreModel.h instead.

@import CoreData;
#import "NSManagedObject+MDPManagedObject.h"

extern const struct MDPBasketBoxscoreModelAttributes {
	__unsafe_unretained NSString *absoluteMinute;
	__unsafe_unretained NSString *awayTeamScore;
	__unsafe_unretained NSString *currentQuarterAwayTeamPartialScore;
	__unsafe_unretained NSString *currentQuarterHomeTeamPartialScore;
	__unsafe_unretained NSString *currentQuarterScoreDifference;
	__unsafe_unretained NSString *homeTeamScore;
	__unsafe_unretained NSString *lastUpdateAt;
	__unsafe_unretained NSString *quarter;
	__unsafe_unretained NSString *scoreDifference;
	__unsafe_unretained NSString *time;
} MDPBasketBoxscoreModelAttributes;

extern const struct MDPBasketBoxscoreModelRelationships {
	__unsafe_unretained NSString *basketLiveMatchBoxscoreEvolution;
	__unsafe_unretained NSString *basketLiveMatchBoxscoreEvolutionResume;
	__unsafe_unretained NSString *basketLiveMatchBoxscorePerQuarter;
} MDPBasketBoxscoreModelRelationships;

@class MDPBasketLiveMatchModel;
@class MDPBasketLiveMatchModel;
@class MDPBasketLiveMatchModel;

@interface _MDPBasketBoxscoreModel : NSManagedObject

@property (nonatomic, strong) NSNumber* absoluteMinute;

@property (atomic) int64_t absoluteMinuteValue;
- (int64_t)absoluteMinuteValue;
- (void)setAbsoluteMinuteValue:(int64_t)value_;

//- (BOOL)validateAbsoluteMinute:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSNumber* awayTeamScore;

@property (atomic) int64_t awayTeamScoreValue;
- (int64_t)awayTeamScoreValue;
- (void)setAwayTeamScoreValue:(int64_t)value_;

//- (BOOL)validateAwayTeamScore:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSNumber* currentQuarterAwayTeamPartialScore;

@property (atomic) int64_t currentQuarterAwayTeamPartialScoreValue;
- (int64_t)currentQuarterAwayTeamPartialScoreValue;
- (void)setCurrentQuarterAwayTeamPartialScoreValue:(int64_t)value_;

//- (BOOL)validateCurrentQuarterAwayTeamPartialScore:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSNumber* currentQuarterHomeTeamPartialScore;

@property (atomic) int64_t currentQuarterHomeTeamPartialScoreValue;
- (int64_t)currentQuarterHomeTeamPartialScoreValue;
- (void)setCurrentQuarterHomeTeamPartialScoreValue:(int64_t)value_;

//- (BOOL)validateCurrentQuarterHomeTeamPartialScore:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSNumber* currentQuarterScoreDifference;

@property (atomic) int64_t currentQuarterScoreDifferenceValue;
- (int64_t)currentQuarterScoreDifferenceValue;
- (void)setCurrentQuarterScoreDifferenceValue:(int64_t)value_;

//- (BOOL)validateCurrentQuarterScoreDifference:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSNumber* homeTeamScore;

@property (atomic) int64_t homeTeamScoreValue;
- (int64_t)homeTeamScoreValue;
- (void)setHomeTeamScoreValue:(int64_t)value_;

//- (BOOL)validateHomeTeamScore:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSDate* lastUpdateAt;

//- (BOOL)validateLastUpdateAt:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSNumber* quarter;

@property (atomic) int64_t quarterValue;
- (int64_t)quarterValue;
- (void)setQuarterValue:(int64_t)value_;

//- (BOOL)validateQuarter:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSNumber* scoreDifference;

@property (atomic) int64_t scoreDifferenceValue;
- (int64_t)scoreDifferenceValue;
- (void)setScoreDifferenceValue:(int64_t)value_;

//- (BOOL)validateScoreDifference:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* time;

//- (BOOL)validateTime:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) MDPBasketLiveMatchModel *basketLiveMatchBoxscoreEvolution;

//- (BOOL)validateBasketLiveMatchBoxscoreEvolution:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) MDPBasketLiveMatchModel *basketLiveMatchBoxscoreEvolutionResume;

//- (BOOL)validateBasketLiveMatchBoxscoreEvolutionResume:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) MDPBasketLiveMatchModel *basketLiveMatchBoxscorePerQuarter;

//- (BOOL)validateBasketLiveMatchBoxscorePerQuarter:(id*)value_ error:(NSError**)error_;

@end

@interface _MDPBasketBoxscoreModel (CoreDataGeneratedPrimitiveAccessors)

- (NSNumber*)primitiveAbsoluteMinute;
- (void)setPrimitiveAbsoluteMinute:(NSNumber*)value;

- (int64_t)primitiveAbsoluteMinuteValue;
- (void)setPrimitiveAbsoluteMinuteValue:(int64_t)value_;

- (NSNumber*)primitiveAwayTeamScore;
- (void)setPrimitiveAwayTeamScore:(NSNumber*)value;

- (int64_t)primitiveAwayTeamScoreValue;
- (void)setPrimitiveAwayTeamScoreValue:(int64_t)value_;

- (NSNumber*)primitiveCurrentQuarterAwayTeamPartialScore;
- (void)setPrimitiveCurrentQuarterAwayTeamPartialScore:(NSNumber*)value;

- (int64_t)primitiveCurrentQuarterAwayTeamPartialScoreValue;
- (void)setPrimitiveCurrentQuarterAwayTeamPartialScoreValue:(int64_t)value_;

- (NSNumber*)primitiveCurrentQuarterHomeTeamPartialScore;
- (void)setPrimitiveCurrentQuarterHomeTeamPartialScore:(NSNumber*)value;

- (int64_t)primitiveCurrentQuarterHomeTeamPartialScoreValue;
- (void)setPrimitiveCurrentQuarterHomeTeamPartialScoreValue:(int64_t)value_;

- (NSNumber*)primitiveCurrentQuarterScoreDifference;
- (void)setPrimitiveCurrentQuarterScoreDifference:(NSNumber*)value;

- (int64_t)primitiveCurrentQuarterScoreDifferenceValue;
- (void)setPrimitiveCurrentQuarterScoreDifferenceValue:(int64_t)value_;

- (NSNumber*)primitiveHomeTeamScore;
- (void)setPrimitiveHomeTeamScore:(NSNumber*)value;

- (int64_t)primitiveHomeTeamScoreValue;
- (void)setPrimitiveHomeTeamScoreValue:(int64_t)value_;

- (NSDate*)primitiveLastUpdateAt;
- (void)setPrimitiveLastUpdateAt:(NSDate*)value;

- (NSNumber*)primitiveQuarter;
- (void)setPrimitiveQuarter:(NSNumber*)value;

- (int64_t)primitiveQuarterValue;
- (void)setPrimitiveQuarterValue:(int64_t)value_;

- (NSNumber*)primitiveScoreDifference;
- (void)setPrimitiveScoreDifference:(NSNumber*)value;

- (int64_t)primitiveScoreDifferenceValue;
- (void)setPrimitiveScoreDifferenceValue:(int64_t)value_;

- (NSString*)primitiveTime;
- (void)setPrimitiveTime:(NSString*)value;

- (MDPBasketLiveMatchModel*)primitiveBasketLiveMatchBoxscoreEvolution;
- (void)setPrimitiveBasketLiveMatchBoxscoreEvolution:(MDPBasketLiveMatchModel*)value;

- (MDPBasketLiveMatchModel*)primitiveBasketLiveMatchBoxscoreEvolutionResume;
- (void)setPrimitiveBasketLiveMatchBoxscoreEvolutionResume:(MDPBasketLiveMatchModel*)value;

- (MDPBasketLiveMatchModel*)primitiveBasketLiveMatchBoxscorePerQuarter;
- (void)setPrimitiveBasketLiveMatchBoxscorePerQuarter:(MDPBasketLiveMatchModel*)value;

@end
