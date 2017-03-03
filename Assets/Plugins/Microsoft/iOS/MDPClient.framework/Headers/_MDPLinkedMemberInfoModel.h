//
//  _MDPLinkedMemberInfoModel.m
//  MDPClient
//
//  Created automatically with Mogenerator Templates.
//  Copyright (c) 2014 Microsoft. All rights reserved.
//

// DO NOT EDIT. This file is machine-generated and constantly overwritten.
// Make changes to MDPLinkedMemberInfoModel.h instead.

@import CoreData;
#import "NSManagedObject+MDPManagedObject.h"

extern const struct MDPLinkedMemberInfoModelAttributes {
	__unsafe_unretained NSString *lastUpdateAt;
	__unsafe_unretained NSString *linked;
	__unsafe_unretained NSString *memberNumber;
	__unsafe_unretained NSString *name;
	__unsafe_unretained NSString *secondName;
	__unsafe_unretained NSString *surname;
} MDPLinkedMemberInfoModelAttributes;

@interface _MDPLinkedMemberInfoModel : NSManagedObject

@property (nonatomic, strong) NSDate* lastUpdateAt;

//- (BOOL)validateLastUpdateAt:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSNumber* linked;

@property (atomic) BOOL linkedValue;
- (BOOL)linkedValue;
- (void)setLinkedValue:(BOOL)value_;

//- (BOOL)validateLinked:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSNumber* memberNumber;

@property (atomic) int64_t memberNumberValue;
- (int64_t)memberNumberValue;
- (void)setMemberNumberValue:(int64_t)value_;

//- (BOOL)validateMemberNumber:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* name;

//- (BOOL)validateName:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* secondName;

//- (BOOL)validateSecondName:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* surname;

//- (BOOL)validateSurname:(id*)value_ error:(NSError**)error_;

@end

@interface _MDPLinkedMemberInfoModel (CoreDataGeneratedPrimitiveAccessors)

- (NSDate*)primitiveLastUpdateAt;
- (void)setPrimitiveLastUpdateAt:(NSDate*)value;

- (NSNumber*)primitiveLinked;
- (void)setPrimitiveLinked:(NSNumber*)value;

- (BOOL)primitiveLinkedValue;
- (void)setPrimitiveLinkedValue:(BOOL)value_;

- (NSNumber*)primitiveMemberNumber;
- (void)setPrimitiveMemberNumber:(NSNumber*)value;

- (int64_t)primitiveMemberNumberValue;
- (void)setPrimitiveMemberNumberValue:(int64_t)value_;

- (NSString*)primitiveName;
- (void)setPrimitiveName:(NSString*)value;

- (NSString*)primitiveSecondName;
- (void)setPrimitiveSecondName:(NSString*)value;

- (NSString*)primitiveSurname;
- (void)setPrimitiveSurname:(NSString*)value;

@end
