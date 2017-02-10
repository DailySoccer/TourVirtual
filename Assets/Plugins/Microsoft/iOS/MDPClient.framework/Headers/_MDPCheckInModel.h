//
//  _MDPCheckInModel.m
//  MDPClient
//
//  Created automatically with Mogenerator Templates.
//  Copyright (c) 2014 Microsoft. All rights reserved.
//

// DO NOT EDIT. This file is machine-generated and constantly overwritten.
// Make changes to MDPCheckInModel.h instead.

@import CoreData;
#import "NSManagedObject+MDPManagedObject.h"

extern const struct MDPCheckInModelAttributes {
	__unsafe_unretained NSString *checkInDate;
	__unsafe_unretained NSString *idChekInType;
	__unsafe_unretained NSString *idUser;
	__unsafe_unretained NSString *lastUpdateAt;
} MDPCheckInModelAttributes;

extern const struct MDPCheckInModelRelationships {
	__unsafe_unretained NSString *location;
	__unsafe_unretained NSString *pagesCheckInsResults;
} MDPCheckInModelRelationships;

@class MDPLocationModel;
@class MDPPagedCheckInsModel;

@interface _MDPCheckInModel : NSManagedObject

@property (nonatomic, strong) NSDate* checkInDate;

//- (BOOL)validateCheckInDate:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* idChekInType;

//- (BOOL)validateIdChekInType:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* idUser;

//- (BOOL)validateIdUser:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSDate* lastUpdateAt;

//- (BOOL)validateLastUpdateAt:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) MDPLocationModel *location;

//- (BOOL)validateLocation:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSSet *pagesCheckInsResults;

- (NSMutableSet*)pagesCheckInsResultsSet;

@end

@interface _MDPCheckInModel (PagesCheckInsResultsCoreDataGeneratedAccessors)
- (void)addPagesCheckInsResults:(NSSet*)value_;
- (void)removePagesCheckInsResults:(NSSet*)value_;
- (void)addPagesCheckInsResultsObject:(MDPPagedCheckInsModel*)value_;
- (void)removePagesCheckInsResultsObject:(MDPPagedCheckInsModel*)value_;
@end

@interface _MDPCheckInModel (CoreDataGeneratedPrimitiveAccessors)

- (NSDate*)primitiveCheckInDate;
- (void)setPrimitiveCheckInDate:(NSDate*)value;

- (NSString*)primitiveIdChekInType;
- (void)setPrimitiveIdChekInType:(NSString*)value;

- (NSString*)primitiveIdUser;
- (void)setPrimitiveIdUser:(NSString*)value;

- (NSDate*)primitiveLastUpdateAt;
- (void)setPrimitiveLastUpdateAt:(NSDate*)value;

- (MDPLocationModel*)primitiveLocation;
- (void)setPrimitiveLocation:(MDPLocationModel*)value;

- (NSMutableSet*)primitivePagesCheckInsResults;
- (void)setPrimitivePagesCheckInsResults:(NSMutableSet*)value;

@end
