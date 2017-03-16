//
//  _MDPGroupThreadModel.m
//  MDPClient
//
//  Created automatically with Mogenerator Templates.
//  Copyright (c) 2014 Microsoft. All rights reserved.
//

// DO NOT EDIT. This file is machine-generated and constantly overwritten.
// Make changes to MDPGroupThreadModel.h instead.

@import CoreData;
#import "NSManagedObject+MDPManagedObject.h"

extern const struct MDPGroupThreadModelAttributes {
	__unsafe_unretained NSString *endDate;
	__unsafe_unretained NSString *idCompetition;
	__unsafe_unretained NSString *idMatch;
	__unsafe_unretained NSString *idSeason;
	__unsafe_unretained NSString *idThread;
	__unsafe_unretained NSString *isMainThread;
	__unsafe_unretained NSString *lastUpdateAt;
	__unsafe_unretained NSString *purpose;
	__unsafe_unretained NSString *startDate;
} MDPGroupThreadModelAttributes;

extern const struct MDPGroupThreadModelRelationships {
	__unsafe_unretained NSString *descriptionGroupThread;
	__unsafe_unretained NSString *groupThreads;
} MDPGroupThreadModelRelationships;

@class MDPLocaleDescriptionModel;
@class MDPGroupModel;

@interface _MDPGroupThreadModel : NSManagedObject

@property (nonatomic, strong) NSDate* endDate;

//- (BOOL)validateEndDate:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* idCompetition;

//- (BOOL)validateIdCompetition:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* idMatch;

//- (BOOL)validateIdMatch:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* idSeason;

//- (BOOL)validateIdSeason:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* idThread;

//- (BOOL)validateIdThread:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSNumber* isMainThread;

@property (atomic) BOOL isMainThreadValue;
- (BOOL)isMainThreadValue;
- (void)setIsMainThreadValue:(BOOL)value_;

//- (BOOL)validateIsMainThread:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSDate* lastUpdateAt;

//- (BOOL)validateLastUpdateAt:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSNumber* purpose;

@property (atomic) int64_t purposeValue;
- (int64_t)purposeValue;
- (void)setPurposeValue:(int64_t)value_;

//- (BOOL)validatePurpose:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSDate* startDate;

//- (BOOL)validateStartDate:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSSet *descriptionGroupThread;

- (NSMutableSet*)descriptionGroupThreadSet;

@property (nonatomic, strong) MDPGroupModel *groupThreads;

//- (BOOL)validateGroupThreads:(id*)value_ error:(NSError**)error_;

@end

@interface _MDPGroupThreadModel (DescriptionGroupThreadCoreDataGeneratedAccessors)
- (void)addDescriptionGroupThread:(NSSet*)value_;
- (void)removeDescriptionGroupThread:(NSSet*)value_;
- (void)addDescriptionGroupThreadObject:(MDPLocaleDescriptionModel*)value_;
- (void)removeDescriptionGroupThreadObject:(MDPLocaleDescriptionModel*)value_;
@end

@interface _MDPGroupThreadModel (CoreDataGeneratedPrimitiveAccessors)

- (NSDate*)primitiveEndDate;
- (void)setPrimitiveEndDate:(NSDate*)value;

- (NSString*)primitiveIdCompetition;
- (void)setPrimitiveIdCompetition:(NSString*)value;

- (NSString*)primitiveIdMatch;
- (void)setPrimitiveIdMatch:(NSString*)value;

- (NSString*)primitiveIdSeason;
- (void)setPrimitiveIdSeason:(NSString*)value;

- (NSString*)primitiveIdThread;
- (void)setPrimitiveIdThread:(NSString*)value;

- (NSNumber*)primitiveIsMainThread;
- (void)setPrimitiveIsMainThread:(NSNumber*)value;

- (BOOL)primitiveIsMainThreadValue;
- (void)setPrimitiveIsMainThreadValue:(BOOL)value_;

- (NSDate*)primitiveLastUpdateAt;
- (void)setPrimitiveLastUpdateAt:(NSDate*)value;

- (NSNumber*)primitivePurpose;
- (void)setPrimitivePurpose:(NSNumber*)value;

- (int64_t)primitivePurposeValue;
- (void)setPrimitivePurposeValue:(int64_t)value_;

- (NSDate*)primitiveStartDate;
- (void)setPrimitiveStartDate:(NSDate*)value;

- (NSMutableSet*)primitiveDescriptionGroupThread;
- (void)setPrimitiveDescriptionGroupThread:(NSMutableSet*)value;

- (MDPGroupModel*)primitiveGroupThreads;
- (void)setPrimitiveGroupThreads:(MDPGroupModel*)value;

@end
